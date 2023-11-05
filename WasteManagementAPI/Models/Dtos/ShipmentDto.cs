using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Models.Dtos
{
    public class ShipmentDto
    {
        
        public int Weight { get; set; } 

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }
       
       public ICollection<WasteTypes> WasteTypes { get; set; } =  new List<WasteTypes>();

    }
}
