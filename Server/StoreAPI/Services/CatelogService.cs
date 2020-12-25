using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using StoreAPI.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Services
{
    public class CatelogService : ControllerBase, ICatelogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatelogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IActionResult> CreateAsync(CatelogModel obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var catelogs = await _unitOfWork.Catelog.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Catelog>, IEnumerable<CatelogModel>>(catelogs));
        }

        public Task<IActionResult> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> GetPagesAsync(PaginationModel pagination)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> UpdateAsync(CatelogModel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}