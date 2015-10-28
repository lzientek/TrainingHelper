/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TrainingHelper.PcClient"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TrainingHelper.PcClient.ViewModel.Exercises;

namespace TrainingHelper.PcClient.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ConnectionViewModel>();
            SimpleIoc.Default.Register<MyDataViewModel>();
            SimpleIoc.Default.Register<ExercisesViewModel>();
            SimpleIoc.Default.Register<ProgramsViewModel>();
            SimpleIoc.Default.Register<ExercisesOverviewViewModel>();
            SimpleIoc.Default.Register<DetailsExercisesViewModel>();
            Connection.UserConnection += Main.UserConnection;
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ConnectionViewModel Connection => ServiceLocator.Current.GetInstance<ConnectionViewModel>();

        public MyDataViewModel MyData => ServiceLocator.Current.GetInstance<MyDataViewModel>();
        public ExercisesViewModel Exercises => ServiceLocator.Current.GetInstance<ExercisesViewModel>();
        public ExercisesOverviewViewModel ExercisesOverview => ServiceLocator.Current.GetInstance<ExercisesOverviewViewModel>();
        public DetailsExercisesViewModel ExerciseDetails => ServiceLocator.Current.GetInstance<DetailsExercisesViewModel>();
        public ProgramsViewModel Programs => ServiceLocator.Current.GetInstance<ProgramsViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}