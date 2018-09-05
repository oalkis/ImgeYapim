using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Models
{
    public class Crew

    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CrewID { get; set; }
        [StringLength(100)]
        public string CrewName { get; set; }
        [StringLength(500)]
        public string CrewPicture { get; set; }
        [StringLength(50)]
        public string CrewPhone { get; set; }
        [StringLength(100)]
        public string CrewMail { get; set; }
        [StringLength(100)]
        public string CrewJob { get; set; }
        [StringLength(100)]
        public string CrewTwitter { get; set; }
        [StringLength(100)]
        public string CrewInstagram { get; set; }

        [AllowHtml]
        public string CrewAbout { get; set; }
    }
}