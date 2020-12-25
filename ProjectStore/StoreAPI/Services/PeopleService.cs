using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;

namespace StoreAPI.Services
{
    public class PeopleService : ControllerBase, IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PeopleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateAsync(PeopleModel obj)
        {
            var peopletmp = await _unitOfWork.People.GetByEmailAsync(obj.username);
            if (peopletmp == null)
                return BadRequest(new { success = false, message = "Email đã tồn tại" });

            var people = _mapper.Map<PeopleModel, People>(obj);
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

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);

            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            await _unitOfWork.People.RemoveAsync(people);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Xóa thành công" });
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var people = await _unitOfWork.People.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(people));
        }

        public async Task<IActionResult> GetByEmail(string email)
        {
            var people = await _unitOfWork.People.GetByEmailAsync(email);
            if (people == null)
                return BadRequest(new { success = false, message = "Email không tồn tại" });
            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);

            return Ok(_mapper.Map<People, PeopleModel>(people));
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);
            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });
            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);

            return Ok(_mapper.Map<People, PeopleModel>(people));
        }

        public async Task<IActionResult> GetPagesAsync(PaginationModel pagination)
        {
            var peoples = await _unitOfWork.People.GetAllAsync();
            var peopleModels = _mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(peoples);
            if (!string.IsNullOrEmpty(pagination.searchValue))
            {
                peopleModels = peopleModels.Where(a =>
                    a.name.ToLower().Contains(pagination.searchValue.ToLower()));
            }
            return Ok(PaginationList<PeopleModel>.Create(peopleModels, pagination.currentPage, pagination.pageSize));
        }

        public async Task<IActionResult> LoginAsync(LoginModel login)
        {
            var people = await _unitOfWork.People.GetByEmailAsync(login.email);
            if (people == null)
                return BadRequest(new { success = false, message = "Email không tồn tại" });

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(login.password));

            for (int i = 0; i < bytes.Length; i++)
                hash.Append(bytes[i].ToString("x2"));

            var password = hash.ToString();

            if (people.password == password)
                return BadRequest(new { success = false, message = "Email không tồn tại" });

            return Ok(new { success = true, data = _mapper.Map<People, PeopleModel>(people) });
        }

        public async Task<IActionResult> UpdateAsync(PeopleModel obj)
        {
            var people = await _unitOfWork.People.GetByIdAsync(obj.id);
            if (people == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(people.password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            obj.password = hash.ToString();

            _mapper.Map<PeopleModel, People>(obj, people);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, data = _mapper.Map<People, PeopleModel>(people), message = "Sửa thành công." });
        }
    }
}