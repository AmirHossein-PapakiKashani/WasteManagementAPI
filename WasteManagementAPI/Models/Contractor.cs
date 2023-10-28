namespace WasteManagementAPI.Models
{
    public class Contractor
    {
        public Contractor() => Municipality = new HashSet<Municipality>();

        public int ContractorId { get; set; }

        public string Nmae { get; set; } = string.Empty;

        public string Family { get; set; } = string.Empty;

        //FK
        public int EmployeeId { get; set; }
        //navigation propertiy
        public Employee Employee { get; set; } = null!;

        public ICollection<Municipality> Municipality { get; set;} = null!;
    }
}
