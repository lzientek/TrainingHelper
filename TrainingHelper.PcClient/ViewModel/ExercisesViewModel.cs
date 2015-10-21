using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using GalaSoft.MvvmLight;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;

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
            set { _exercises = value; RaisePropertyChanged(); }
        }

        public ExercisesViewModel()
        {

        }

        public async void Load()
        {
            using (var prov = new ExercicesProvider())
            {
                Exercises = new ObservableCollection<FullExerciseNL>(await prov.GetAllExercises());
            }
        }


    }
}