using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeoples()
        {
            var peoples = await _unitOfWork.People.GetAllAsync();
            foreach (People people in peoples)
                people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);
            return Ok(_mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(peoples));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeople(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);
            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });
            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);

            return Ok(_mapper.Map<People, PeopleModel>(people));
        }

        [HttpGet("pages")]
        public async Task<IActionResult> GetPages(PaginationModel paginationModel)
        {
            var peoples = await _unitOfWork.People.GetAllAsync();
            var peopleModels = _mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(peoples);
            if (!string.IsNullOrEmpty(paginationModel.searchValue))
            {
                peopleModels = peopleModels.Where(a =>
                    a.name.ToLower().Contains(paginationModel.searchValue.ToLower()));
            }
            return Ok(PaginationList<PeopleModel>.Create(peopleModels, paginationModel.currentPage, paginationModel.pageSize));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePeople(PeopleModel peopleModel)
        {
            var peopletmp = await _unitOfWork.People.GetByEmailAsync(peopleModel.username);
            if (peopletmp != null)
                return BadRequest(new { success = false, message = "Email đã tồn tại" });

            var people = _mapper.Map<PeopleModel, People>(peopleModel);
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(people.password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            people.password = hash.ToString();

            await _unitOfWork.People.AddAsync(people);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Tạo thành công" });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePeople(int id, PeopleModel peopleModel)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);
            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(people.password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            peopleModel.password = hash.ToString();

            _mapper.Map<PeopleModel, People>(peopleModel, people);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, data = _mapper.Map<People, PeopleModel>(people), message = "Sửa thành công." });
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);

            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            await _unitOfWork.People.RemoveAsync(people);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Xóa thành công" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var people = await _unitOfWork.People.GetByEmailAsync(loginModel.username);
            if (people == null)
                return BadRequest(new { success = false, message = "Tài khoảng không tồn tại" });

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(loginModel.password));
            for (int i = 0; i < bytes.Length; i++)
                hash.Append(bytes[i].ToString("x2"));
            var password = hash.ToString();

            if (people.password == password)
                return BadRequest(new { success = false, message = "Mật khẩu không đúng" });

            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);

            var peopleModel = _mapper.Map<People, PeopleModel>(people);

            var token = GenerateJSONWebToken(peopleModel);

            return Ok(new { success = true, data = new AccountModel(peopleModel, token) });
        }

        private string GenerateJSONWebToken(PeopleModel peopleModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, peopleModel.name),
            //        new Claim(ClaimTypes.Email, peopleModel.username),
            //        new Claim("id", peopleModel.id.ToString()),
            //        new Claim(ClaimTypes.Role, peopleModel.Role.roleName),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    };

            var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
                                             audience: _config["Jwt:Issuer"],
                                             //claims: authClaims,
                                             notBefore: null,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
