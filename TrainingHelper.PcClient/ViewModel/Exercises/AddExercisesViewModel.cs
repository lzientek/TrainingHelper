using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;
using TrainingHelper.PcClient.Common;

namespace TrainingHelper.PcClient.ViewModel
{

    public class AddExercisesViewModel : ViewModelBase
    {
        public FullExerciseNL Exercise { get; set; }

        public RelayCommand Add { get; set; }

        public Action Close { get; set; }

        public AddExercisesViewModel()
        {
            Exercise = new FullExerciseNL() { Id = 0 };
            Add = new RelayCommand(OnAdd, CanAdd);
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Exercise.Name);
        }

        [LoadingMethod]
        private async void OnAdd()
        {
            using (var prov = new ExercicesProvider())
            {
                Exercise = await prov.CreateExercise(Exercise);
                Messenger.Default.Send(new ObjectManipulation<FullExerciseNL>(Exercise, Manipulation.Create));
            }
            Close?.Invoke();
        }
    }
}