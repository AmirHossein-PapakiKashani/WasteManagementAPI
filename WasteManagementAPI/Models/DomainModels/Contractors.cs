namespace WasteManagementAPI.Models.DomainModels
{
    public class Contractors
    {
       
        public int ContractorId { get; set; }

        public string Nmae { get; set; } = string.Empty;
        
        //forigen key
        public int MunicipalityId { get; set; }

        //nav property
        public Municipalities Municipalities { get; set; } = null!;

    }
}
