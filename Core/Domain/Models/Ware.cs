namespace ShopApi.Core.Domain.Models{
    public class Ware{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int UnitTypeId { get; set; }
        public WareUnitType UnitType { get; set; } = new WareUnitType();
    }
}