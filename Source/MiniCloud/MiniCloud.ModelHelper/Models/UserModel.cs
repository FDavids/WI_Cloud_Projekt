using System;
using System.ComponentModel.DataAnnotations;
using MiniCloud.DataModel;
using MiniCloud.ModelHelper.Helper;
using Newtonsoft.Json;

namespace MiniCloud.ModelHelper.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public UserModel(User databaseUser)
        {
            if (databaseUser == null)
            {
                throw new ArgumentNullException();
            }

            UserName = databaseUser.UserName;
            Password = databaseUser.Password;
            Name = databaseUser.Name;          
        }

        public UserModel(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }

        [Required]
        [MaxLength(250)]
        [Display(Name = "loginName")]
        [JsonProperty(PropertyName = "loginName")]
        [UniqueUserName(ErrorMessage = "This user has already been added to the database")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "passwort")]
        [JsonProperty(PropertyName = "passwort")]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Name")]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
