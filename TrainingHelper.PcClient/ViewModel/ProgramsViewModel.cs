using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using TrainingHelper.DataProvider.Exercises;
using TrainingHelper.DataProvider.Programs;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.Programs;
using TrainingHelper.Models.User;

namespace TrainingHelper.PcClient.ViewModel
{

    public class ProgramsViewModel : ViewModelBase
    {
        private ObservableCollection<ShortProgram> _trainings;

        public ObservableCollection<ShortProgram> Programs
        {
            get
            {
                if (_trainings == null)
                {
                    Load();
                }
                return _trainings;
            }
            set { _trainings = value; RaisePropertyChanged(); }
        }

        public NavigationService Navigation { get; set; }

        public ProgramsViewModel()
        {

        }

        public async void Load()
        {
            using (var prov = new ProgramsProvider())
            {
                Programs = new ObservableCollection<ShortProgram>(await prov.GetAllPrograms());
            }
        }


    }

    
}