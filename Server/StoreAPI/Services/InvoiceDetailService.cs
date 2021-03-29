using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using StoreAPI.Interfaces;

namespace StoreAPI.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateAsync(InvoiceDetailModel obj)
        {
            try
            {
                var invoiceDetail = _mapper.Map<InvoiceDetailModel, InvoiceDetail>(obj);

                await _unitOfWork.InvoiceDetail.AddAsync(invoiceDetail);
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
            var invoiceDetail = await _unitOfWork.InvoiceDetail.GetByIdAsync(id);

            if (invoiceDetail == null) return false;
            try
            {
                await _unitOfWork.InvoiceDetail.RemoveAsync(invoiceDetail);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<InvoiceDetailModel>> GetAllAsync()
        {
            var invoiceDetails = await _unitOfWork.InvoiceDetail.GetAllAsync();
            foreach (var item in invoiceDetails)
            {
                if (item.productID != null)
                    item.Product = await _unitOfWork.Product.GetByIdAsync((int)item.productID);
            }
            return _mapper.Map<IEnumerable<InvoiceDetail>, IEnumerable<InvoiceDetailModel>>(invoiceDetails);
        }

        public async Task<InvoiceDetailModel> GetByIdAsync(int id)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetail.GetByIdAsync(id);
            if (invoiceDetail.productID != null)
                invoiceDetail.Product = await _unitOfWork.Product.GetByIdAsync((int)invoiceDetail.productID);
            return _mapper.Map<InvoiceDetail, InvoiceDetailModel>(invoiceDetail);
        }

        public async Task<IEnumerable<InvoiceDetailModel>> GetByInvoiceASync(int id)
        {
            var invoiceDetails = await _unitOfWork.InvoiceDetail.GetAllAsync();
            invoiceDetails = invoiceDetails.Where(i => i.invoiceID == id);
            if (invoiceDetails != null)
                foreach (var item in invoiceDetails)
                    item.Product = await _unitOfWork.Product.GetByIdAsync((int)item.productID);
            return _mapper.Map<IEnumerable<InvoiceDetail>, IEnumerable<InvoiceDetailModel>>(invoiceDetails);
        }

        public async Task<InvoiceDetailModel> GetByProductAsync(int invoiceId, int productId)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetail.GetByProductAsync(invoiceId, productId);
            if (invoiceDetail != null)
                invoiceDetail.Product = await _unitOfWork.Product.GetByIdAsync((int)invoiceDetail.productID);
            return _mapper.Map<InvoiceDetail, InvoiceDetailModel>(invoiceDetail);
        }

        public Task<PaginationList<InvoiceDetailModel>> GetPagesAsync(PaginationModel pagination)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(InvoiceDetailModel obj)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetail.GetByIdAsync(obj.id);
            if (invoiceDetail == null) return false;

            try
            {
                _mapper.Map<InvoiceDetailModel, InvoiceDetail>(obj, invoiceDetail);
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
