//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataProject_Final
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderUpdates
    {
        public int UpdateId { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public Nullable<int> OrderNumber { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}