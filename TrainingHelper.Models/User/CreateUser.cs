using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHelper.Models.User
{
    public class CreateUser
    {
        public string Pseudo { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
