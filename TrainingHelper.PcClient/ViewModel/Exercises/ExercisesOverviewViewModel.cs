using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.PcClient.Common;
using TrainingHelper.PcClient.Common.Helpers;

namespace TrainingHelper.PcClient.ViewModel
{
    public class ExercisesOverviewViewModel : ViewModelBase
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
        public RelayCommand ReloadCommand { get; set; }
        public RelayCommand<int> ShowDetailsCommand { get; set; }

        public ExercisesOverviewViewModel()
        {
            Messenger.Default.Register<ObjectManipulation<FullExerciseNL>>(this, MessengerChanges);
            ReloadCommand = new RelayCommand(Load);
            ShowDetailsCommand = new RelayCommand<int>(ExercisesViewModel.GoToDetails);
        }


        [LoadingMethod]
        public async void Load()
        {
            using (var prov = new ExercicesProvider())
            {
                Exercises = new ObservableCollection<FullExerciseNL>(await prov.GetAllExercises());
            }
        }


        #region Messenger methods
        private void MessengerChanges(ObjectManipulation<FullExerciseNL> objectManipulation)
        {
            Exercises?.ManipulateCollection(objectManipulation);
        }
        #endregion
    }
}
