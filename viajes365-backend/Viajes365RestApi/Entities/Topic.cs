<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    public class Topic : Base
    {
        [Key]
        public long TourId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        [StringLength(20)]
        public string Duration { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }

        public ICollection<Tour_attraction> Tour_Attractions { get; set; }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes365RestApi.Entities
{
    public class Topic
    {
>>>>>>> develop
    }
}
