using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Interfaces;

namespace StoreAPI.Services
{
    public class ProductService : ControllerBase, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateAsync(ProductModel obj)
        {
            var product = _mapper.Map<ProductModel, Product>(obj);

            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Tạo thành công" });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            await _unitOfWork.Product.RemoveAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, message = "Xóa thành công" });
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _unitOfWork.Product.GetAllAsync();
            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products));
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });
            product.Catelog = await _unitOfWork.Catelog.GetByIdAsync(product.catelogID);
            return Ok(_mapper.Map<Product, ProductModel>(product));
        }

        public async Task<IActionResult> GetPagesAsync(PaginationModel pagination)
        {
            var products = await _unitOfWork.Product.GetAllAsync();

            if (!string.IsNullOrEmpty(pagination.searchValue))
                products = products.Where(a =>
                    a.productName.ToLower().Contains(pagination.searchValue.ToLower()));

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
                products = products.Where(a => a.price >= pagination.fromPrice).Where(a => a.price <= pagination.toPrice);

            if (pagination.sort == "ASC")
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

            if (pagination.sort == "DESC")
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
            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);

            var productModels = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products);

            return Ok(PaginationList<ProductModel>.Create(productModels, pagination.currentPage, pagination.pageSize));
        }

        public async Task<IActionResult> GetNewProductASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.createdDate).Take(number);
            else
                products = products.OrderByDescending(p => p.createdDate).Take(number);

            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products));
        }

        public async Task<IActionResult> UpdateAsync(ProductModel obj)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(obj.id);
            if (product == null)
                return BadRequest(new { success = false, message = "Id không tồn tại" });

            _mapper.Map<ProductModel, Product>(obj, product);
            await _unitOfWork.CompleteAsync();

            return Ok(new { success = true, data = _mapper.Map<Product, ProductModel>(product), message = "Sửa thành công." });
        }

        public async Task<IActionResult> GetTopSellingASync(int catelogID, int number = 10)
        {
            var catelog = await _unitOfWork.Catelog.GetByIdAsync(catelogID);
            var products = await _unitOfWork.Product.GetAllAsync();

            if (catelog != null)
                products = products.Where(p => p.catelogID == catelogID).OrderByDescending(p => p.sale).Take(number);
            else
                products = products.OrderByDescending(p => p.createdDate).Take(number);

            foreach (var item in products)
                item.Catelog = await _unitOfWork.Catelog.GetByIdAsync(item.catelogID);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products));
        }
    }
}