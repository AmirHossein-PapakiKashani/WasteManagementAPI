namespace WasteManagementAPI.Models.DomainModels
{
    public class Employee
    {
        public Employee() => Contractors = new HashSet<Contractor>();

        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        public ICollection<Contractor> Contractors { get; set; }
    }
}
