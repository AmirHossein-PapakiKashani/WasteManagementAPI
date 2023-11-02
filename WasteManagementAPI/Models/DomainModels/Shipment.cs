namespace WasteManagementAPI.Models.DomainModels
{
    public class Shipment
    {
        public int ShipmentId { get; set; }

        public string Weight { get; set; }

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }


    }
}
