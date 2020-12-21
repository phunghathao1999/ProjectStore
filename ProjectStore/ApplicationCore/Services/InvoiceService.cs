using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Status;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ChangeStatus(int id, string status)
        {
            var invoice = await _unitOfWork.Invoice.GetByIdAsync(id);
            if (invoice == null) return false;
            try
            {
                invoice.status = status;
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(InvoiceModel obj)
        {
            try
            {
                var invoice = _mapper.Map<InvoiceModel, Invoice>(obj);
                await _unitOfWork.Invoice.AddAsync(invoice);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<InvoiceModel>> GetAllAsync()
        {
            var invoices = await _unitOfWork.Invoice.GetAllAsync();
            return _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceModel>>(invoices);
        }

        public async Task<InvoiceModel> GetByStatusAsync(int peopleId, string status)
        {
            var invoice = await _unitOfWork.Invoice.GetByStatusAsync(peopleId, status);
            return _mapper.Map<Invoice, InvoiceModel>(invoice);
        }

        public async Task<InvoiceModel> GetByIdAsync(int id)
        {
            var invoice = await _unitOfWork.Invoice.GetByIdAsync(id);
            return _mapper.Map<Invoice, InvoiceModel>(invoice);
        }

        public Task<PaginationList<InvoiceModel>> GetPagesAsync(PaginationModel pagination)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(InvoiceModel obj)
        {
            var invoice = await _unitOfWork.Invoice.GetByIdAsync(obj.id);
            if (invoice == null) return false;

            try
            {
                _mapper.Map<InvoiceModel, Invoice>(obj, invoice);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<InvoiceModel>> GetByCustomerASync(int customerId)
        {
            var invoices = await _unitOfWork.Invoice.GetAllAsync();
            if (invoices != null)
            {
                invoices = invoices.Where(a => a.customerID == customerId).OrderByDescending(a => a.createdDate);
                foreach(var item in invoices)
                {
                    item.Customer = await _unitOfWork.People.GetByIdAsync(item.customerID);
                    if(item.shipperID != null)
                        item.Shipper = await _unitOfWork.People.GetByIdAsync((int)item.shipperID);
                }
            }
            return _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceModel>>(invoices);
        }
    }
}
