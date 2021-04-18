<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

=======
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> remotes/origin/develop
namespace Viajes365RestApi.Entities
{
    public class Attraction : Base
    {
<<<<<<< HEAD
        [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
        [Required]
=======
         [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
>>>>>>> remotes/origin/develop
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
<<<<<<< HEAD

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }


        public ICollection<Tour_attraction> Tour_Attractions { get; set; }
=======
        // [ForeignKey("FK_Attraction_Location_LocationId")]
        // public long LocationId { get; set; }
        // public virtual Location Location { get; set; }
        public ICollection<Photo> Photos { get; set; }
>>>>>>> remotes/origin/develop
    }
}
