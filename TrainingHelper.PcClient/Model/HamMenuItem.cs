using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TrainingHelper.PcClient.Model
{
    public class HamMenuItem
    {
        public string Title { get; set; }
        public bool IsWindowed { get; set; }
        public UserControl Content { get; set; }
    }
}
