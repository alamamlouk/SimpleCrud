using AutoMapper;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Entity;

namespace SimpleCrud.Mapper
{
    public class AutoMapperProfileProduct : Profile
    {
        public AutoMapperProfileProduct(){
            CreateMap<Product, GetProductResponse>();
            CreateMap<AddProductRequest, Product>();
            CreateMap<Product, AddProductResponse>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, UpdateProductResponse>();
        }
    }
}
