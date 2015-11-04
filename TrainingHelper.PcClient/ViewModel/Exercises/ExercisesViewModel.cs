using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;
using TrainingHelper.PcClient.Common;
using TrainingHelper.PcClient.Common.Helpers;
using TrainingHelper.PcClient.Views.Exercices;

namespace TrainingHelper.PcClient.ViewModel
{

    public class ExercisesViewModel : ViewModelBase
    {
        private static NavigationService _navigation;

        public AddExercisesViewModel AddExercisesVm => new AddExercisesViewModel();

        public ExercisesViewModel()
        {
            CreateNew = new RelayCommand(OpenNewExerciseWindow);
            GoBack = new RelayCommand(NavGoBack,NavCanGoBack);
        }

        

        #region Command
        public RelayCommand CreateNew { get; set; }
        public RelayCommand GoBack { get; set; }
        private void OpenNewExerciseWindow()
        {
            var wd = new NewExerciseWindow();
            wd.Show();
        }

        #endregion

        #region Navigation

        public static NavigationService Navigation
        {
            get { return _navigation; }
            set
            {
                _navigation = value;
            }
        }

        public static void GoToOverview()
        {
            Navigation.Navigate(new OverviewPage());
        }
        public static void GoToDetails(int id)
        {
            Navigation.Navigate(new DetailsPage(id));
        }

        public static void GoToEdit(int id)
        {
            Navigation.Navigate(new DetailsPage(id,true));
        }

        private bool NavCanGoBack()
        {
            return Navigation != null && Navigation.CanGoBack && Navigation.Content.GetType() != typeof(OverviewPage);
        }

        private void NavGoBack()
        {
            Navigation?.GoBack();
        }

        #endregion

    }
}