//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiOrionHospital
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patientdata
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string HealthIssues { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public System.DateTime CreatedOnDateTime { get; set; }
        public System.DateTime LastVisitDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
