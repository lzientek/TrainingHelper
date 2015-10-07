using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TrainingHelper.DataProvider.User;
using TrainingHelper.Models.User;

namespace TrainingHelper.StandaloneApiServer.Controlers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly UserProvider _userProvider = new UserProvider();

        [HttpPost]
        public async Task<FullUser> CreateUser([FromBody]CreateUser user)
        {
            return await _userProvider.CreateUser(user);
        }

        [HttpGet]
        [Authorize]
        [Route("{userId}/userInfo")]
        public async Task<IEnumerable<UserInfos>> GetUserInfos(int userId)
        {
            return await _userProvider.GetUserInfos(userId);

        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IEnumerable<SmallUser>> GetUsers()
        {
            return await _userProvider.GetUsers();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _userProvider.Dispose();
            }
        }
    }
}
