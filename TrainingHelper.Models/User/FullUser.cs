using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHelper.Models.User
{
    public class FullUser:SmallUser
    {
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public DateTime LastConnection { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhotoPath { get; set; }

        public string DisplayName { get { return $"{FirstName} {LastName}"; } }
    }
}
