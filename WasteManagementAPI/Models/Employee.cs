namespace WasteManagementAPI.Models
{
    public class Employee
    {
        public Employee() => Citizens = new HashSet<Citizen>();
       
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        public ICollection<Citizen> Citizens { get; set; } = null!;
    }
}
