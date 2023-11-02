namespace WasteManagementAPI.Models.DomainModels
{
    public class CollectionBooth
    {
        public int CollectionBoothId { get; set; }

        public string CollectionBoothName { get; set; } = string.Empty;

        public string EmployeeName { get; set; } = string.Empty;

        public string EmployeeUserName { get; set; } = string.Empty;

        public string EmployeePasswored { get; set; } = string.Empty;
    }
}
