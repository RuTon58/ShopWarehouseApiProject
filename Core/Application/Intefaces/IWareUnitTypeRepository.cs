using ShopApi.Core.Domain.Dtos.WareUtitType;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Core.Application.Intefaces{
    public interface IWareUnitTypeRepository{
        Task<List<WareUnitType>> GetAllAsync();
        Task<WareUnitType?> GetByIdAsync(int id);
        Task<WareUnitType> CreateAsync(WareUnitType wareUnitTypeModel);
        Task<WareUnitType?> UpdateAsync(int id, UpdateWareUnitTypeDto wareUnitTypeDto);
        Task<WareUnitType?> DeleteAsync(int id);
    }
}