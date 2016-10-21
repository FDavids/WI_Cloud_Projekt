using System.Collections.Generic;
using System.Linq;
using MiniCloud.DataModel;
using MiniCloud.ModelHelper.Models;

namespace MiniCloud.ModelHelper.Helper
{
    public class UserHelper
    {
        private readonly EntityContext m_Context;

        public UserHelper()
        {
            m_Context = new EntityContext();
        }

        public UserModel Register(UserModel model)
        {
            var user = CreateUser(model);

            m_Context.Users.Add(user);

            m_Context.SaveChanges();

            return model;
        }

        public UserModel GetUserByUserName(string userName)
        {
            var databaseUser = m_Context.Users.FirstOrDefault(x => x.UserName.Equals(userName, System.StringComparison.InvariantCultureIgnoreCase));

            return databaseUser != null ? new UserModel(databaseUser) : null;
        }

        public IEnumerable<BasicUserInformation> GetAllUsers()
        {
            var allDatabaseUsers = m_Context.Users.ToList();

            var users = new List<BasicUserInformation>();

            foreach (var user in allDatabaseUsers)
            {
                users.Add(new BasicUserInformation(user.UserName, user.Name));
            }

            return users;
        }

        private static User CreateUser(UserModel model)
        {
            return new User
            {
                Name = model.Name,
                UserName = model.UserName,
                Password = model.Password, 
            };
        }

        public bool CheckLoginInformation(string userName, string password)
        {
            var user = GetUserByUserName(userName);

            return user?.Password.Equals(password) ?? false;
        }
    }
}
