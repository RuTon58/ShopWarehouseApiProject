using Microsoft.EntityFrameworkCore;
using ShopApi.Core.Application.Data;
using ShopApi.Core.Application.Intefaces;
using ShopApi.Core.Domain.Dtos.WareUtitType;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Infrastructure.Repositories{
    public class WareUtitTypeRepository : IWareUnitTypeRepository{
        private readonly ApplicationDbContext _context;
        
        public WareUtitTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WareUnitType>> GetAllAsync()
        {
            return await _context.WareUnitTypes.ToListAsync();
        }

        public async Task<WareUnitType?> GetByIdAsync(int id)
        {
            return await _context.WareUnitTypes.FirstOrDefaultAsync(unitType => unitType.Id == id);
        }

        public async Task<WareUnitType> CreateAsync(WareUnitType wareUnitTypeModel)
        {
            await _context.WareUnitTypes.AddAsync(wareUnitTypeModel);
            await _context.SaveChangesAsync();

            return wareUnitTypeModel;
        }

        public async Task<WareUnitType?> UpdateAsync(int id, UpdateWareUnitTypeDto wareUnitTypeDto)
        {
            var wareUnitTypeModel = await _context.WareUnitTypes.FirstOrDefaultAsync(unitType => unitType.Id == id);

            if (wareUnitTypeModel == null){
                return null;
            }

            wareUnitTypeModel.Name = wareUnitTypeDto.Name;

            await _context.SaveChangesAsync();

            return wareUnitTypeModel;
        }

        public async Task<WareUnitType?> DeleteAsync(int id)
        {
            var wareUnitTypeModel = await _context.WareUnitTypes.FirstOrDefaultAsync(unitType => unitType.Id == id);
            
            if (wareUnitTypeModel == null){
                return null;
            }

            _context.WareUnitTypes.Remove(wareUnitTypeModel);
            await _context.SaveChangesAsync();

            return wareUnitTypeModel;
        }
    }
}