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
    
    public partial class DeletedVehicles
    {
        public string VehicleNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> TestValidityDate { get; set; }
        public Nullable<System.DateTime> EntryCompany { get; set; }
        public string Remarks { get; set; }
        public string Img { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public Nullable<int> NumberReason { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        public virtual ReasonsDeleteVehicles ReasonsDeleteVehicles { get; set; }
        public virtual VehiclesTypes VehiclesTypes { get; set; }
    }
}
