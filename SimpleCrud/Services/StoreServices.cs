using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Interface.Store;
using SimpleCrud.Mapper;
using SimpleCrud.Models;

namespace SimpleCrud.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public StoreServices(ApplicationDBContext context,IMapper mapper)
        {

            _mapper = mapper;
            _context = context;
        }
        public async Task<GetStoreResponse> FindStore(int StoreId)
        {

            var foundStore = await _context.Store.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == StoreId);
            if (foundStore == null)
            {
                return null;
            }
            
            return _mapper.Map<GetStoreResponse>(foundStore);
            
       
        }
        public async Task<List<GetStoreResponse>> GetAllStores()
        {
            // ASK how to minimize this section

            var stores = await _context.Store.Include(s=>s.Products).ToListAsync();
            List<GetStoreResponse> newStores= stores.Select(s=> _mapper.Map<GetStoreResponse>(s)).ToList();
            return newStores;
        }


        public async Task<AddStoreResponse> AddStore(AddStoreRequest addStoreRequest)
        {
                var newStore = _context.Store.Add(_mapper.Map<Store>(addStoreRequest));
                await _context.SaveChangesAsync();
                return _mapper.Map<AddStoreResponse>(newStore.Entity);
          
        }


        public async Task<UpdateStoreResponse> UpdateStore(int StoreId, UpdateStoreRequest updateStoreRequest)
        {
            Store findStore = await _context.Store.FindAsync(StoreId);
            if (findStore == null)
            {
                return null;
            }
            findStore.StoreOwner = updateStoreRequest.StoreOwner;
            findStore.StoreName = updateStoreRequest.StoreName;
            _context.Store.Update(findStore);
            await _context.SaveChangesAsync();
            return _mapper.Map<UpdateStoreResponse>(findStore);
        }
        public async Task<string> DeleteStore(int StoreId)
        {
            var store = await _context.Store.FindAsync(StoreId);
            if (store == null)
            {
                return "no Store found with the Id ";
            }
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
            return "Store Deleted Successfully";    
         }
        public async Task<string> EmptyStoreTable()
        {
            _context.Store.RemoveRange(_context.Store);
            await _context.SaveChangesAsync();
            return "Store Table Emptied";
        }

    }
}
