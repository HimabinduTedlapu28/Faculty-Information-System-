//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacultyInformation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHistory
    {
        public int WorkHistoryID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.DateTime> JobBeginDate { get; set; }
        public Nullable<System.DateTime> JobEndDate { get; set; }
        public string JobResponsibilities { get; set; }
        public string JobType { get; set; }
    
        public virtual Faculty Faculty { get; set; }
    }
}