using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
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

        private ObservableCollection<FullExerciseNL> _exercises;

        public ObservableCollection<FullExerciseNL> Exercises
        {
            get
            {
                if (_exercises == null)
                {
                    Load();
                }
                return _exercises;
            }
            set
            {
                _exercises = value; RaisePropertyChanged();
            }
        }

        public AddExercisesViewModel AddExercisesVm => new AddExercisesViewModel();

        public ExercisesViewModel()
        {
            Reload = new RelayCommand(Load);
            CreateNew = new RelayCommand(OpenNewExerciseWindow);
            Messenger.Default.Register<ObjectManipulation<FullExerciseNL>>(this,MessengerChanges);
        }




        [LoadingMethod]
        public async void Load()
        {
            using (var prov = new ExercicesProvider())
            {
                Exercises = new ObservableCollection<FullExerciseNL>(await prov.GetAllExercises());
            }
        }

        #region Command
        public RelayCommand CreateNew { get; set; }
        private void OpenNewExerciseWindow()
        {
            var wd = new NewExerciseWindow();
            wd.Show();
        }
        public RelayCommand Reload { get; set; }

        #endregion

        #region Messenger methods
        private void MessengerChanges(ObjectManipulation<FullExerciseNL> objectManipulation)
        {
            Exercises?.ManipulateCollection(objectManipulation);
        }
        #endregion

    }
}