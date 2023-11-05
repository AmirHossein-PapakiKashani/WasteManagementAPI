namespace WasteManagementAPI.Models.DomainModels
{
    public class Shipments
    {


        public int ShipmentsId { get; set; }

        public int Weight { get; set; } 

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }
       

        //foregin key 
        public int CitizensId { get; set; }

        //navigation propertty
        public Citizens Citizens { get; set; } = null!;

        //forigen key
        public int CollectionBoothsId { get; set; }
        //navigation prop
        public CollectionBooths CollectionBooths { get; set; } = null !;
        
        //navigation
        public ICollection<WasteTypes> WasteTypes { get; set; } =  new List<WasteTypes>();
    }
}
