namespace WasteManagementAPI.Models.DomainModels
{
    public class Shipments
    {


        public int ShipmentsId { get; set; }

        public int Weight { get; set; } 

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }

        public ICollection<Citizens> Citizens { get; set; } = new List<Citizens>();



    }
}
