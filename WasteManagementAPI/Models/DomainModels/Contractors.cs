namespace WasteManagementAPI.Models.DomainModels
{
    public class Contractors
    {
       

        public int ContractorId { get; set; }

        public string Nmae { get; set; } = string.Empty;



        
        public ICollection<Municipalities> Municipality { get; set; }
    }
}
