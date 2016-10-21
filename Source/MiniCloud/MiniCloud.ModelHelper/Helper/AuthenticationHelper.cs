using System.Linq;
using MiniCloud.DataModel;
using MiniCloud.ModelHelper.Models;

namespace MiniCloud.ModelHelper.Helper
{
    public class AuthenticationHelper
    {
        public bool DoesUserExist(LoginRequestModel loginRequestModel)
        {
            if (loginRequestModel == null)
            {
                return false;
            }

            using (var context = new EntityContext())
            {
                return context.Users.Any(x => x.UserName.Equals(loginRequestModel.UserName, System.StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(loginRequestModel.Password));
            }
        }
    }
}
