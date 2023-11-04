using Microsoft.Identity.Client;

namespace WasteManagementAPI.Models.DomainModels
{
    public class Supervisors
    {
        
        public int SupervisorsId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SupervisorUserName { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        //forigen key
        public int MunicipalityId { get; set; }
        //nav prop
        public Municipalities Municipalities { get; set;} = null!;
    }
}
