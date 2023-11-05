using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Models.Dtos
{
    public class ShipmentDto
    {
        
        public int ShipmentsId { get; set; }

        public int Weight { get; set; }

        public int CitizenId { get; set; }

        //public int CollectionBoothId { get; set; }
        //public int PointsAllocated { get; set; }

        //public bool ApproveBySupervisor { get; set; }

        public  string WasteTypes { get; set; } 

    }
}
