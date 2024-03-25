using Microsoft.EntityFrameworkCore;
using ShopApi.Core.Application.Data;
using ShopApi.Core.Application.Intefaces;
using ShopApi.Core.Domain.Dtos.Ware;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Infrastructure.Repositories{
    public class WareRepository : IWareRepository{
        private readonly ApplicationDbContext _context;
        public WareRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ware>> GetAllAsync()
        {
            return await _context.Wares.Include(ware => ware.UnitType).ToListAsync();
        }
        public async Task<Ware?> GetByIdAsync(int id)
        {
            return await _context.Wares.Include(ware => ware.UnitType).FirstOrDefaultAsync(ware => ware.Id == id);
        }

        public async Task<Ware> CreateAsync(Ware wareModel)
        {
            await _context.Wares.AddAsync(wareModel);
            await _context.SaveChangesAsync();

            return wareModel;
        }

        public async Task<Ware?> UpdateAsync(int id, Ware newWareDto)
        {
            var updateWareModel = await _context.Wares.Include(ware => ware.UnitType).FirstOrDefaultAsync(ware => ware.Id == id);
            
            if (updateWareModel == null){
                return null;
            }

            updateWareModel.Name = newWareDto.Name;
            updateWareModel.Count = newWareDto.Count;
            updateWareModel.UnitPrice = newWareDto.UnitPrice;
            updateWareModel.UnitTypeId = newWareDto.UnitTypeId;
            updateWareModel.UnitType = newWareDto.UnitType;

            await _context.SaveChangesAsync();

            return updateWareModel;
        }
        
        public async Task<Ware?> DeleteAsync(int id)
        {
            var wareModel = await _context.Wares.Include(ware => ware.UnitType).FirstOrDefaultAsync(ware => ware.Id == id);

            if (wareModel == null){
                return null;
            }

            _context.Wares.Remove(wareModel);
            await _context.SaveChangesAsync();

            return wareModel;
        }
    }
}