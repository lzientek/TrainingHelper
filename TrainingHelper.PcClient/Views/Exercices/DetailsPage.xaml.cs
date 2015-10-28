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
using TrainingHelper.PcClient.ViewModel.Exercises;

namespace TrainingHelper.PcClient.Views.Exercices
{
    /// <summary>
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage(int id)
        {
            InitializeComponent();
            (DataContext as DetailsExercisesViewModel)?.Load(id);
        }

    }
}
