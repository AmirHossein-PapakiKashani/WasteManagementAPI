namespace WasteManagementAPI.Models.DomainModels
{
    public class Supervisor
    {
        public Supervisor() => Municipality = new HashSet<Municipality>();

        public int SupervisorId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsOk { get; set; }

        public ICollection<Municipality> Municipality { get; set; }

    }
}
