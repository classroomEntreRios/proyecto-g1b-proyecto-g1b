<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> develop
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
=======
=======
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> remotes/origin/develop
>>>>>>> develop
namespace Viajes365RestApi.Entities
{
    public class Attraction : Base
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> develop
        [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
        [Required]
<<<<<<< HEAD
=======
=======
         [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
>>>>>>> remotes/origin/develop
>>>>>>> develop
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> develop

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }


        public ICollection<Tour_attraction> Tour_Attractions { get; set; }
<<<<<<< HEAD
=======
=======
        // [ForeignKey("FK_Attraction_Location_LocationId")]
        // public long LocationId { get; set; }
        // public virtual Location Location { get; set; }
        public ICollection<Photo> Photos { get; set; }
>>>>>>> remotes/origin/develop
>>>>>>> develop
    }
}
