using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Models.DatabaseContext
{
    public class DJ
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DJID { get; set; }
        [StringLength(100)]
        public string DJName { get; set; }
        [StringLength(500)]
        public string DJPicture { get; set; }
        [AllowHtml]
        public string DJAbout { get; set; }
        public int DJOrder { get; set; }
    }
}