using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Models
{
    public class Product
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(500)]
        public string ProductAddress { get; set; }
        [AllowHtml]
        public string ProductAbout { get; set; }
        public string ProductPhone { get; set; }
        [StringLength(100)]
        public string ProductMail { get; set; }
        [StringLength(100)]
        public string ProductTwitter { get; set; }
        [StringLength(100)]
        public string ProductInstagram { get; set; }
        [StringLength(100)]
        public string ProductFacebook { get; set; }

    }
}