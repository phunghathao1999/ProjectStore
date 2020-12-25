using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PeopleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(PeopleModel obj)
        {
            try
            {
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);

            if (people == null) return false;
            try
            {
                await _unitOfWork.People.RemoveAsync(people);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PeopleModel>> GetAllAsync()
        {
            var people = await _unitOfWork.People.GetAllAsync();
            return _mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(people);
        }

        public async Task<PeopleModel> GetByEmail(string email)
        {
            var people = await _unitOfWork.People.GetByEmailAsync(email);
            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);
            return _mapper.Map<People, PeopleModel>(people);
        }

        public async Task<PeopleModel> GetByIdAsync(int id)
        {
            var people = await _unitOfWork.People.GetByIdAsync(id);
            people.Role = await _unitOfWork.Role.GetByIdAsync(people.role_ID);
            return _mapper.Map<People, PeopleModel>(people);
        }

        public async Task<PaginationList<PeopleModel>> GetPagesAsync(PaginationModel pagination)
        {
            var peoples = await _unitOfWork.People.GetAllAsync();
            var peopleModels = _mapper.Map<IEnumerable<People>, IEnumerable<PeopleModel>>(peoples);
            if (!string.IsNullOrEmpty(pagination.searchValue))
            {
                peopleModels = peopleModels.Where(a =>
                    a.name.ToLower().Contains(pagination.searchValue.ToLower()));
            }
            return (PaginationList<PeopleModel>)PaginationList<PeopleModel>.Create(peopleModels, pagination.currentPage, pagination.pageSize);
        }

        public async Task<bool> LoginAsync(LoginModel login)
        {
            var people = await _unitOfWork.People.GetByEmailAsync(login.email);
            if (people != null)
            {
                StringBuilder hash = new StringBuilder();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(login.password));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }

                var password = hash.ToString();
                if (people.password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateAsync(PeopleModel obj)
        {
            var people = await _unitOfWork.People.GetByIdAsync(obj.id);
            if (people != null) return false;

            try
            {
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
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}