namespace WasteManagementAPI.Models.DomainModels
{
    public class CollectionBooths
    {
        public int CollectionBoothsId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string EmployeeUserName { get; set; } = string.Empty;

        public string EmployeePasswored { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        ////nav property
        //public ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();

        //nav property
        public ICollection<Shipments> Shipments { get; set; } = new List<Shipments>();
    }
}
