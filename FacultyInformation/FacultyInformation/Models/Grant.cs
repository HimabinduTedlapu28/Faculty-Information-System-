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
    
    public partial class Grant
    {
        public int GrantID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public string GrantTitle { get; set; }
        public string GrantDescription { get; set; }
    
        public virtual Faculty Faculty { get; set; }
    }
}