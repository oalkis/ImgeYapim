using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgeYapim.Models
{
    public class Artist
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistID { get; set; }
        [StringLength(100)]
        public string ArtistName { get; set; }
        [StringLength(500)]
        public string ArtistPicture { get; set; }
        [AllowHtml]
        public string ArtistAbout { get; set; }
    }
}