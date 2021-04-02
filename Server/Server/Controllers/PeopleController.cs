using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController()
        {
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PeopleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeoples()
        {
            var people = await _unitOfWork.People.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(people));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPeople(int id)
        //{
        //    return await _peopleService.GetByIdAsync(id);
        //}

        //[HttpGet("pages")]
        //public async Task<IActionResult> GetPages(PaginationModel paginationModel)
        //{
        //    return await _peopleService.GetPagesAsync(paginationModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreatePeople(PeopleModel peopleModel)
        //{
        //    return await _peopleService.CreateAsync(peopleModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdatePeople(int id, PeopleModel peopleModel)
        //{
        //    return await _peopleService.UpdateAsync(peopleModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeletePeople(int id)
        //{
        //    return await _peopleService.DeleteAsync(id);
        //}


        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginModel loginModel)
        //{
        //    return await _peopleService.LoginAsync(loginModel);
        //}
    }
}
