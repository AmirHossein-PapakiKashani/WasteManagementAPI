namespace WasteManagementAPI.Models
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Mayor { get; set; } = string.Empty;
        
        //FK of contractor
        public int ContractorId { get; set; }
        
        //navigation property
        public Contractor Contractor { get; set; } = null!;


    }
}
