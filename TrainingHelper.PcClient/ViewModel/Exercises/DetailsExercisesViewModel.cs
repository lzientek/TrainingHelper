using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.Models.Exercises;

namespace TrainingHelper.PcClient.ViewModel.Exercises
{
    public class DetailsExercisesViewModel : ViewModelBase
    {
        private FullExercise _exercise;

        public FullExercise Exercise
        {
            get { return _exercise; }
            set { _exercise = value;RaisePropertyChanged(); }
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand GoToOverviewCommand { get; set; }

        public DetailsExercisesViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            GoToOverviewCommand = new RelayCommand(ExercisesViewModel.GoToOverview);
        }


        public async void Load(int exerciseId)
        {
            using (var prov = new ExercicesProvider())
            {
                Exercise = await prov.GetFullExercise(exerciseId);
            }
        }


        public async void Save()
        {
            using (var prov = new ExercicesProvider())
            {
                Exercise = await prov.SaveExercise(Exercise);
            }
        }
    }
}
