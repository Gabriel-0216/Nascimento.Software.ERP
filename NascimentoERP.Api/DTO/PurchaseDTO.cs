namespace NascimentoERP.Api.DTO
{
    public class PurchaseDTO
    {
        public string BuyerId { get; set; }
        public List<ProductsDTO> Products { get; set; }
    }
}
