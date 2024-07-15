using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTO.StoreDTO;
using SimpleCrud.Interface.Store;
using SimpleCrud.Mapper;
using SimpleCrud.Models;

namespace SimpleCrud.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly ApplicationDBContext _context;
        public StoreServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<FindStoreResponseDTO> FindStore(int StoreId)
        {
    
            var foundStore = await _context.Store.FindAsync(StoreId);
            if(foundStore == null)
            {
                return null;
            }
            FindStoreResponseDTO findStoreResponseDTO= foundStore.FindStoreToDTO();
            return findStoreResponseDTO;
            
       
        }
        public async Task<List<FindStoreResponseDTO>> GetAllStores()
        {
            // ASK how to minimize this section
            var fetchedStores = new List<FindStoreResponseDTO>();
            var stores = await _context.Store.ToListAsync();
            foreach (var store in stores)
            {
                fetchedStores.Add(store.FindStoreToDTO());
            }
            return fetchedStores;
        }


        public async Task<AddStoreResponseDTO> AddStore(AddStoreRequestDTO addStoreRequestDTO)
        {
            try
            {
                if (addStoreRequestDTO.StoreName == null || addStoreRequestDTO.StoreOwner == null)
                {
                    throw new Exception();
                }
                var newStore = _context.Store.Add(addStoreRequestDTO.DTOtoStore());
                await _context.SaveChangesAsync();
                AddStoreResponseDTO response = newStore.Entity.AddStoreToDTO();
                return response;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //Ask if there is a simple way to add 
       
        public async Task<UpdateStoreResponseDTO> UpdateStore(int StoreId,UpdateStoreRequestDTO UpdateStoreRequestDTO)
        {
            Store store = await _context.Store.FindAsync(StoreId);
            if (store== null)
            {
                return null;
            }
            store.StoreOwner=UpdateStoreRequestDTO.StoreOwner;
            store.StoreName=  UpdateStoreRequestDTO.StoreName;
            _context.Store.Update(store);
            await _context.SaveChangesAsync();
            return store.StoreToUpdateStoreResponseDTO();
        }
        public async Task DeleteStore(int StoreId)
        {
            var store = await _context.Store.FindAsync(StoreId);
            if (store == null)
            {
                return;
            }
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
        }
        public async Task EmptyStoreTable()
        {
            _context.Store.RemoveRange(_context.Store);
            await _context.SaveChangesAsync();
        }

    }
}
