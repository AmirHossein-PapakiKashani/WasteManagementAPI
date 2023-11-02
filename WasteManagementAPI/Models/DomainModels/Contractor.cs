namespace WasteManagementAPI.Models.DomainModels
{
    public class Contractor
    {
       

        public int ContractorId { get; set; }

        public string Nmae { get; set; } = string.Empty;



        
        public ICollection<Municipality> Municipality { get; set; }
    }
}
