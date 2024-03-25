using ShopApi.Core.Domain.Dtos.Ware;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Infrastructure.Mappers{
    public static class WareMapper{
        public static WareDto ToDto(this Ware wareModel){
            return new WareDto{
                Id = wareModel.Id,
                Name = wareModel.Name,
                Count = wareModel.Count,
                UnitPrice = wareModel.UnitPrice,
                UnitType = wareModel.UnitType.ToDto(),
            };
        }

        public static Ware ToModelFromCreateDto(this CreateWareDto wareDto, WareUnitType wareUnitTypeModel){
            return new Ware{
                Name = wareDto.Name,
                Count = wareDto.Count,
                UnitPrice = wareDto.UnitPrice,
                UnitTypeId = wareUnitTypeModel.Id,
                UnitType = wareUnitTypeModel,
            };
        }

        public static Ware ToModelFromUpdateDto(this UpdateWareDto wareDto, WareUnitType wareUnitTypeModel){
            return new Ware{
                Name = wareDto.Name,
                Count = wareDto.Count,
                UnitPrice = wareDto.UnitPrice,
                UnitTypeId = wareUnitTypeModel.Id,
                UnitType = wareUnitTypeModel,
            };
        }
    }
}