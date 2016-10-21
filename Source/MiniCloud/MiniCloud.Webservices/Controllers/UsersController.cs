using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MiniCloud.ModelHelper;
using MiniCloud.ModelHelper.Helper;
using MiniCloud.ModelHelper.Models;

namespace MiniCloud.WebServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        /// <summary>
        /// Get all users from the database.
        /// </summary>
        [ResponseType(typeof(List<BasicUserInformation>))]
        public IHttpActionResult Get()
        {
            var userHelper = new UserHelper();

            return Ok(userHelper.GetAllUsers());
        }

        /// <summary>
        /// Gets the User for the given name, otherwise returns 404 NotFound.
        /// </summary>
        /// <param name="userName">The user name that should be checked</param>
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult Get(string userName)

        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest(ErrorMessages.InvalidRequestParameters);
            }

            var userHelper = new UserHelper();

            var user = userHelper.GetUserByUserName(userName);

            if (user != null)
            {
                return Ok(user);
            }

            return Content(HttpStatusCode.NotFound, "The user '" + userName + "' could not be found.");
        }

        /// <summary>
        /// Add the given user to the database. The client can add the detailed longitude and latitude from the homeadress (default: lng/lat from postcode)
        /// </summary>
        [ResponseType(typeof(UserModel))]
        public IHttpActionResult Post([FromBody] UserModel model)
        {
            if (model == null)
            {
                return BadRequest(ErrorMessages.InvalidRequestBody);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationHelper = new UserHelper();
            registrationHelper.Register(model);

            //LogHelper.Log($"New user '{model.UserName}' was added to database", LogType.Info);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult CheckLoginInformation(string userName, string password)
        {
            var userHelper = new UserHelper();

            var isValid = userHelper.CheckLoginInformation(userName, password);

            if (isValid)
            {
                return Ok(userHelper.GetUserByUserName(userName));
            }

            return Unauthorized();
        }
    }
}