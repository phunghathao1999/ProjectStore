using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class CatelogService : ICatelogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatelogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> CreateAsync(CatelogModel obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CatelogModel>> GetAllAsync()
        {
            var catelogs = await _unitOfWork.Catelog.GetAllAsync();
            return _mapper.Map<IEnumerable<Catelog>, IEnumerable<CatelogModel>>(catelogs);
        }

        public Task<CatelogModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginationList<CatelogModel>> GetPagesAsync(PaginationModel pagination)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(CatelogModel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}