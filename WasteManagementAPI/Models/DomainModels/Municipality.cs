namespace WasteManagementAPI.Models.DomainModels
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Mayor { get; set; } = string.Empty;

        //FK of contractor
        public int ContractorId { get; set; }

        //navigation property
        public Contractor Contractor { get; set; } = null!;

        //FK
        public int SupervisorId { get; set; }

        // nav prop
        public Supervisor Supervisor { get; set; } = null!;
    }
}
