using ApplicationCore.Entity;
using ApplicationCore.Models;
using AutoMapper;

namespace BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Catelog, CatelogModel>();
            CreateMap<CatelogModel, Catelog>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<People, PeopleModel>();
            CreateMap<PeopleModel, People>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<Invoice, InvoiceModel>();
            CreateMap<InvoiceModel, Invoice>();

            CreateMap<InvoiceDetail, InvoiceDetailModel>();
            CreateMap<InvoiceDetailModel, InvoiceDetail>();
        }
    }
}