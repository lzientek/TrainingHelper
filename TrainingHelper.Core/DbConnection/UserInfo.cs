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
    
    public partial class UserInfo
    {
        public int Id { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> AveragePulse { get; set; }
        public string Feeling { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
