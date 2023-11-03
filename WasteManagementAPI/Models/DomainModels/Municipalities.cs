namespace WasteManagementAPI.Models.DomainModels
{
    public class Municipalities
    {
        public int MunicipalityId { get; set; }

        public string MunicipalityName { get; set; } = string.Empty;


        public ICollection<Contractors> Contractors { get; set; } = new List<Contractors>();
    }
}
