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
    
    public partial class Cours
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> CourseCredits { get; set; }
        public Nullable<int> DeptID { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
