using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MiniCloud.ModelHelper.Models
{
    public class BasicUserInformation
    {
        public BasicUserInformation(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }

        [Display(Name = "userName")]
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [Display(Name = "name")]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
