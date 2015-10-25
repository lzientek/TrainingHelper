using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using GalaSoft.MvvmLight;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.User;
using TrainingHelper.PcClient.Common;

namespace TrainingHelper.PcClient.ViewModel
{

    public class MyDataViewModel : ViewModelBase
    {
        private ObservableCollection<MadeExercisesShort> _madeExercises;

        public ObservableCollection<MadeExercisesShort> MadeExercises
        {
            get
            {
                if (_madeExercises == null)
                {
                    Load();
                }
                return _madeExercises;
            }
            set { _madeExercises = value; RaisePropertyChanged(); }
        }

        public MyDataViewModel()
        {

        }

        [LoadingMethod]
        public async void Load()
        {
            using (var prov = new ExercicesProvider())
            {
                MadeExercises = new ObservableCollection<MadeExercisesShort>
                    (await prov.GetMadeExercices(ApplicationHelper.ActualUserId));
            }
        }


    }
}