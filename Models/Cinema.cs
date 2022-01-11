using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Base;
using bioticket.Data.Services;

namespace bioticket.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Biograph Logo")]
        public string Logo { get; set; }
        [Display(Name = "Biograph Navn")]
        public string Name { get; set; }

        [Display(Name = "Biograph Beskrivelse")]
        public string Description { get; set; }

        // Relationships

        public List<Movie> Movies { get; set; }

    }
}
