namespace WasteManagementAPI.Models.DomainModels
{
    public class Supervisors
    {
        public Supervisors() => Municipality = new HashSet<Municipalities>();

        public int SupervisorId { get; set; }

        public string Name { get; set; } = string.Empty;


        public ICollection<Municipalities> Municipality { get; set; }

    }
}
