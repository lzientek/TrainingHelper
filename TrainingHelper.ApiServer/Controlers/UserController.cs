using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TrainingHelper.DataProvider.User;
using TrainingHelper.Models.User;

namespace TrainingHelper.StandaloneApiServer.Controlers
{
    [RoutePrefix("/user")]
    public class UserController : ApiController
    {
        private readonly UserProvider _userProvider = new UserProvider();

        [HttpPost]
        public async Task<FullUser> CreateUser([FromBody]CreateUser user)
        {
            return await _userProvider.CreateUser(user);
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
