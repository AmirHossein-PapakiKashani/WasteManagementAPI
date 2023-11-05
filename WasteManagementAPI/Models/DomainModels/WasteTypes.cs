using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WasteManagementAPI.Models.DomainModels
{
    public class WasteTypes
    {
        public int WasteTypesId { get; set; }

        public string WasteName { get; set;} = string.Empty;

        public int ShipmentsId { get; set; }


        //nav prop
        public Shipments Shipments { get; set; } = null!;
    }
}
