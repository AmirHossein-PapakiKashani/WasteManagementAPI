namespace WasteManagementAPI.Models.DomainModels
{
    public class Shipments
    {


        public int ShipmentsId { get; set; }

        public int Weight { get; set; } 

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }
        
        
        //fk
        public int CitizensId { get; set; }
        //nav
        public Citizens Citizens { get; set; } = null!;



    }
}
