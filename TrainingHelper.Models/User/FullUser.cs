using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHelper.Models.User
{
    public class FullUser
    {
        public string Pseudo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public DateTime LastConnection { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
