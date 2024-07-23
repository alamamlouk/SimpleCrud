using AutoMapper;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Entity;

namespace SimpleCrud.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Store Mapping
            CreateMap<Store, GetStoreResponse>();
            CreateMap<AddStoreRequest, Store>();
            CreateMap<Store, AddStoreResponse>();
            CreateMap<UpdateStoreRequest, Store>();
            CreateMap<Store, UpdateStoreResponse>();
            //Product Mapping
            CreateMap<Product, GetProductResponse>();
            CreateMap<AddProductRequest, Product>();
            CreateMap<Product, AddProductResponse>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, UpdateProductResponse>();

        }
    }
}
