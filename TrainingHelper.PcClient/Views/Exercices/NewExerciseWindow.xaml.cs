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
using System.Windows.Shapes;
using TrainingHelper.PcClient.ViewModel;

namespace TrainingHelper.PcClient.Views.Exercices
{
    /// <summary>
    /// Interaction logic for NewExerciseWindow.xaml
    /// </summary>
    public partial class NewExerciseWindow : Window
    {
        public NewExerciseWindow()
        {
            InitializeComponent();
            var vm = (AddExercisesViewModel) DataContext;
            vm.Close = Close;
        }


    }
}
