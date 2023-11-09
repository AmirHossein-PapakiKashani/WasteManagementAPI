using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WasteManagementAPI.Models.AuthModels
{
    public class UserModel
    {
       
      //  public int? Id { get; set; }

        public string Name { get; set; } 

        public string UserName { get; set; } 

        public string Password { get; set; }  

        public string Role { get; set; } 
    }
}
