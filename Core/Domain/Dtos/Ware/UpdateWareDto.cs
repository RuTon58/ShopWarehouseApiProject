namespace ShopApi.Core.Domain.Dtos.Ware{
    public class UpdateWareDto{
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int UnitTypeId { get; set; }
    }
}