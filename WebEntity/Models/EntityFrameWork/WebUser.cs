//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebEntity.Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> register_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
