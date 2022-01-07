using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioticket.Models
{
    public class Cinema
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
