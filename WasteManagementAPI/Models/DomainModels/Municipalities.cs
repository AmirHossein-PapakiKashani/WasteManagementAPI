namespace WasteManagementAPI.Models.DomainModels
{
    public class Municipalities
    {
        public int MunicipalitiesId { get; set; }

        public string MunicipalityName { get; set; } = string.Empty;

        //nav prop
        public ICollection<Contractors> Contractors { get; set; } = new List<Contractors>();


        //nav property
        public ICollection<Supervisors> Supervisors { get; set; } = new List<Supervisors>();
    }
}
