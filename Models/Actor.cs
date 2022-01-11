using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bioticket.Data.Base;

namespace bioticket.Models
{
    public class Actor:IEntityBase
    {  [Key]
       public int Id { get; set; }
       
        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage = "Profile picture url is required")]
        public string ProfilePictureURL { get; set; }
       
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage ="Full Name must between 3 and 50 chars")]
        public string FullName{ get; set; }
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        //relationships
        public List< Actor_Movie> Actors_Movies { get; set; }

    }
}
