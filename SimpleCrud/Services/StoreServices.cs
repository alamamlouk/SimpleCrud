using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Entity;
using SimpleCrud.Interface.Store;

namespace SimpleCrud.Services
{
    public class StoreServices : IStoreServices
    {
        #region Local variables + Constructor

        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public StoreServices(ApplicationDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        #endregion

        #region Main Methods

        #region Find Store
        public async Task<GetStoreResponse> FindStore(int StoreId) =>
            _mapper.Map<GetStoreResponse>(await _context.Store
                                                        .Include(s => s.Products)
                                                        .FirstOrDefaultAsync(s => s.Id == StoreId));

        #endregion

        #region GetAllStores
        public async Task<List<GetStoreResponse>> GetAllStores(int page = 1, int pageSize = 1) =>
            (await _context.Store.Include(s => s.Products)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync())
                                 .Select(s => _mapper.Map<GetStoreResponse>(s))
                                 .ToList();
        #endregion

        #region AddStore
        public async Task<AddStoreResponse> AddStore(AddStoreRequest addStoreRequest)
        {
            if (addStoreRequest.Owner == null || addStoreRequest.Name == null)
                throw new Exception("fields must not be null");
            Store newStore = _context.Store.Add(_mapper.Map<Store>(addStoreRequest)).Entity;
            await _context.SaveChangesAsync();
            return _mapper.Map<AddStoreResponse>(newStore);
        }
        #endregion

        #region updateStore
        public async Task<UpdateStoreResponse> UpdateStore(int StoreId, UpdateStoreRequest updateStoreRequest)
        {
            Store findStore = await _context.Store
                                            .Include(s => s.Products)
                                            .FirstOrDefaultAsync(s => s.Id == StoreId);
            if (findStore == null)
                throw new Exception("Store not found");
            findStore.Owner = updateStoreRequest.Owner ?? findStore.Owner;
            findStore.Name = updateStoreRequest.Name ?? findStore.Name;
            _context.Store.Update(findStore);
            await _context.SaveChangesAsync();
            return _mapper.Map<UpdateStoreResponse>(findStore);
        }
        #endregion

        #region delete Store
        public async Task<bool> DeleteStore(int StoreId)
        {

            Store store = await _context.Store.FindAsync(StoreId);
            if (store == null)
            {
                return false;
            }
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
            return true;


        }
        #endregion

        #region empty table
        public async Task<bool> EmptyStoreTable()
        {
            _context.Store.RemoveRange(_context.Store);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #endregion


    }
}
