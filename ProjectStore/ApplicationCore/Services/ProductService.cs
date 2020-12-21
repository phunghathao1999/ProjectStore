using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ProductModel obj)
        {
            try
            {
                var product = _mapper.Map<ProductModel, Product>(obj);

                await _unitOfWork.Product.AddAsync(product);
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
            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null) return false;
            try
            {
                await _unitOfWork.Product.RemoveAsync(product);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await _unitOfWork.Product.GetAllAsync();
            foreach (var item in products)
            {
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            }
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            product.Catelog = await _unitOfWork.Catelog.GetByIdAsync(product.catelogID);
            return _mapper.Map<Product, ProductModel>(product);
        }

        public async Task<PaginationList<ProductModel>> GetPagesAsync(PaginationModel pagination)
        {
            var products = await _unitOfWork.Product.GetAllAsync();

            if (!string.IsNullOrEmpty(pagination.searchValue))
            {
                products = products.Where(a =>
                    a.productName.ToLower().Contains(pagination.searchValue.ToLower()));
            }
            if (!string.IsNullOrEmpty(pagination.catelogs))
            {
                List<String> catelogList = new List<String>();
                for (int i = 0; i < pagination.catelogs.Split(",").Length; i++)
                {
                    catelogList.Add(pagination.catelogs.Split(",")[i]);
                }
                products = products.Where(a => catelogList.Contains(a.catelogID.ToString()));
            }
            if ((pagination.fromPrice > 0 && pagination.toPrice == 0) || (pagination.fromPrice == 0 && pagination.toPrice > 0) || (pagination.fromPrice > 0 && pagination.toPrice > 0))
            {
                products = products.Where(a => a.price >= pagination.fromPrice).Where(a => a.price <= pagination.toPrice);
            }
            if (pagination.sort == "ASC")
            {
                switch (pagination.sortKey)
                {
                    case "createdDate":
                        products = products.OrderBy(a => a.createdDate);
                        break;
                    case "price":
                        products = products.OrderBy(a => a.price);
                        break;
                    case "productName":
                        products = products.OrderBy(a => a.productName);
                        break;
                }
            }
            if (pagination.sort == "DESC")
            {
                switch (pagination.sortKey)
                {
                    case "createdDate":
                        products = products.OrderByDescending(a => a.createdDate);
                        break;
                    case "price":
                        products = products.OrderByDescending(a => a.price);
                        break;
                    case "productName":
                        products = products.OrderByDescending(a => a.productName);
                        break;
                }
            }
            foreach (var item in products)
            {
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            }
            var productModels = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);

            return (PaginationList<ProductModel>)PaginationList<ProductModel>.Create(productModels, pagination.currentPage, pagination.pageSize);
        }

        public async Task<IEnumerable<ProductModel>> GetNewProductASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
            {
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.createdDate).Take(number);
            }
            else
            {
                products = products.OrderByDescending(p => p.createdDate).Take(number);
            }
            foreach (var item in products)
            {
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            }
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
        }

        public async Task<bool> UpdateAsync(ProductModel obj)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(obj.id);
            if (product != null) return false;

            try
            {
                _mapper.Map<ProductModel, Product>(obj, product);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetTopSellingASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
            {
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.sale).Take(number);
            }
            else
            {
                products = products.OrderByDescending(p => p.createdDate).Take(number);
            }
            foreach (var item in products)
            {
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            }
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);
        }
    }
}