using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHelper.Models.User
{
    public class ConnectionUser:SmallUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime LastConnection { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
