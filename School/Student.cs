//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int ID { get; set; }
        public string Name_student { get; set; }
        public Nullable<System.DateTime> Birth { get; set; }
        public string Location { get; set; }
        public string Name_father { get; set; }
        public int Studies_id { get; set; }
    
        public virtual Study Study { get; set; }
    }
}
