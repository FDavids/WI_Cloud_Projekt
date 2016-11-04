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
            LastName = databaseUser.LastName;
            FirstName = databaseUser.FirstName;
            EmailAdress = databaseUser.EmailAdress;          
        }

        public UserModel(string userName, string password, string lastName, string firstName, string emailAdress)
        {
            UserName = userName;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            EmailAdress = emailAdress;
        }

       
       [UniqueUserName(ErrorMessage = "This user has already been added to the database")]
        public string UserName { get; set; }

        public string Password { get; set; }       
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAdress { get; set; }
    }
}
