using ShopApi.Core.Domain.Dtos.Ware;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Core.Application.Intefaces{
    public interface IWareRepository{
        Task<List<Ware>> GetAllAsync();
        Task<Ware?> GetByIdAsync(int id);
        Task<Ware> CreateAsync(Ware wareModel);
        Task<Ware?> UpdateAsync(int id, Ware newWareModel);
        Task<Ware?> DeleteAsync(int id);
    }
}
