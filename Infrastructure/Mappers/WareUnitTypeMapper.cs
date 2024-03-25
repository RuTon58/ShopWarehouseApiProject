using ShopApi.Core.Domain.Dtos.WareUtitType;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Infrastructure.Mappers{
    public static class WareUnitTypeMapper{
        public static WareUnitTypeDto ToDto(this WareUnitType wareUnitTypeModel){
            return new WareUnitTypeDto{
                Id = wareUnitTypeModel.Id,
                Name = wareUnitTypeModel.Name,
            };
        }

        public static WareUnitType ToModelFromCreateDto(this CreateWareUnitTypeDto wareUnitTypeDto){
            return new WareUnitType{
                Name = wareUnitTypeDto.Name,
            };
        }
    }
}