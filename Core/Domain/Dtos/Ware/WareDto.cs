using ShopApi.Core.Domain.Dtos.WareUtitType;

namespace ShopApi.Core.Domain.Dtos.Ware{
    public class WareDto{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public WareUnitTypeDto UnitType { get; set; } = new WareUnitTypeDto();
    }
}