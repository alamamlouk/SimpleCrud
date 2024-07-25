using AutoMapper;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Entity;

namespace SimpleCrud.Mapper
{
    public class AutoMapperProfileStore : Profile
    {
        public AutoMapperProfileStore()
        {
            CreateMap<Store, GetStoreResponse>();
            CreateMap<AddStoreRequest, Store>();
            CreateMap<Store, AddStoreResponse>();
            CreateMap<UpdateStoreRequest, Store>();
            CreateMap<Store, UpdateStoreResponse>();
        }
    }
}
