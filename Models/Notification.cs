//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hello_Travellers.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notification
    {
        public int NotificationID { get; set; }
        public string ForUsername { get; set; }
        public string HtmlContent { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public string SeenStatus { get; set; }
    
        public virtual User User { get; set; }
    }
}
