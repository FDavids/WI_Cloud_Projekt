using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MiniCloud.ModelHelper.Models
{
    public class LoginRequestModel
    {
        [Required]
        [Display(Name = "loginName")]
        [JsonProperty(PropertyName = "loginName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "passwort")]
        [JsonProperty(PropertyName = "passwort")]
        public string Password { get; set; }
    }
}
