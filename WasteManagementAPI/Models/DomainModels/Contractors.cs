namespace WasteManagementAPI.Models.DomainModels
{
    public class Contractors
    {
       
        public int ContractorsId { get; set; }

        public string Nmae { get; set; } = string.Empty;

        public int Password { get; set; }
    
        //forigen key
        public int MunicipalitiesId { get; set; }

        //nav property
        public Municipalities Municipalities { get; set; } = null!;

    }
}
