namespace WasteManagementAPI.Models.DomainModels
{
    public class Citizens
    {



        public int CitizensId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int  Points { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; }    = string.Empty;

        public Shipments? Shipments { get; set; } 
    }
}
