//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingHelper.Core.DbConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class MadeExercises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MadeExercises()
        {
            this.MadeSeries = new HashSet<MadeSeries>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public System.DateTime Date { get; set; }
        public string AdditionnalInfo { get; set; }
    
        public virtual TrainingExercise TrainingExercise { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MadeSeries> MadeSeries { get; set; }
    }
}