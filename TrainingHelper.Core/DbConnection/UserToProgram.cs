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
    
    public partial class UserToProgram
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProgramId { get; set; }
        public System.DateTime AddDate { get; set; }
        public Nullable<System.DateTime> FinishedDate { get; set; }
        public string AdditionnalInfos { get; set; }
    
        public virtual TrainingProgram TrainingProgram { get; set; }
        public virtual User User { get; set; }
    }
}