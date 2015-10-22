using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrainingHelper.PcClient.Views.Programs
{
    /// <summary>
    /// Interaction logic for ProgramsUserControl.xaml
    /// </summary>
    public partial class ProgramsUserControl : UserControl
    {
        public ProgramsUserControl()
        {
            InitializeComponent();
            App.ViewModelLocator.Programs.Navigation = Frame.NavigationService;
        }
    }
}
