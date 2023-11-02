namespace WasteManagementAPI.Models.DomainModels
{
    public class Citizen
    {

        public int CitizenId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int  Points { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; }    = string.Empty;


    }
}
