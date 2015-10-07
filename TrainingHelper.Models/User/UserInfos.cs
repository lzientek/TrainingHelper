using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHelper.Models.User
{
    public class UserInfos
    {
        public int Id { get; set; }
        public double? Weight { get; set; }
        public int? Height { get; set; }
        public int? AveragePulse { get; set; }
        public string Feeling { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }

    }
}
