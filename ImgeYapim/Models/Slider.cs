using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImgeYapim.Models
{
    public class Slider
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SliderID { get; set; }
        [StringLength(100)]
        public string SliderName { get; set; }
        [StringLength(500)]
        public string SliderPicture { get; set; }
        public int SliderOrder { get; set; }
    }
}