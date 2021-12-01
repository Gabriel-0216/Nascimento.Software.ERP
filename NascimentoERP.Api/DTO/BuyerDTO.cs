namespace NascimentoERP.Api.DTO
{
    public class BuyerDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? CPF { get; set; }

        public AddressDTO Address { get; set; }
        public List<EmailDTO>? Emails { get; set; }
        public List<CellphoneDTO> cellphones { get; set; }


    }
}
