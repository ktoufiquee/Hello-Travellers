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
    
    public partial class Reply
    {
        public int ReplyID { get; set; }
        public string Content { get; set; }
        public Nullable<int> PostID { get; set; }
        public string CreatorUsername { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
