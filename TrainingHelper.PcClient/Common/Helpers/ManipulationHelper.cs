using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.PcClient.Common.Helpers
{
    public static class ManipulationHelper
    {
        public static void ManipulateCollection<T>(this ObservableCollection<T> collection, ObjectManipulation<T> manipulation) where T : IBaseModel
        {

            if (manipulation.Manipulation == Manipulation.Create)
            {
                collection.Add(manipulation.Value);
            }
            else
            {
                var updatedExercise = collection.FirstOrDefault(o => o.Id == manipulation.Value.Id);
                if (updatedExercise != null)
                {
                    int position = collection.IndexOf(updatedExercise);
                    collection.Remove(updatedExercise);
                    if (manipulation.Manipulation == Manipulation.Update)
                    {
                        collection.Insert(position, manipulation.Value);
                    }
                }
            }

        }
    }
}
