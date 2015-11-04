using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.PcClient.Common;

namespace TrainingHelper.PcClient.ViewModel.Exercises
{
    public class DetailsExercisesViewModel : ViewModelBase
    {
        private FullExercise _exercise;
        private bool _isEditable;

        public FullExercise Exercise
        {
            get { return _exercise; }
            set { _exercise = value;RaisePropertyChanged(); }
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand GoToOverviewCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        public DetailsExercisesViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            EditCommand = new RelayCommand(() => IsEditable =true);
            GoToOverviewCommand = new RelayCommand(ExercisesViewModel.GoToOverview);
        }


        public bool IsEditable
        {
            get { return _isEditable; }
            set { _isEditable = value;RaisePropertyChanged(); }
        }


        public async void Load(int exerciseId)
        {
            using (var prov = new ExercicesProvider())
            {
                Exercise = await prov.GetFullExercise(exerciseId,ApplicationHelper.ActualUserId);
            }
        }

        
        [LoadingMethod]
        public async void Save()
        {
            
            using (var prov = new ExercicesProvider())
            {
                Exercise = await prov.SaveExercise(Exercise);
            }
            Messenger.Default.Send(new ObjectManipulation<FullExerciseNL>(Exercise, Manipulation.Update));

            IsEditable = false;
        }
    }
}
