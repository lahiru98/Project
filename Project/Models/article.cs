//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class article
    {
        public int article_id { get; set; }
        [Required(ErrorMessage = "Please enter topic")]
        [DisplayName("Topic")]
        public string article_topic { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        [DisplayName("Description")]
        public string article_description { get; set; }
        [Required(ErrorMessage = "Please enter publisher name")]
        [DisplayName("Publish By")]
        public string article_publishby { get; set; }
    }
}
