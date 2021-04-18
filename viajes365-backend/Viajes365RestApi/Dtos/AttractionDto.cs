<<<<<<< HEAD
﻿

namespace Viajes365RestApi.Dtos
{
    public class AttractionDto
=======
using Microsoft.CodeAnalysis;
namespace Viajes365RestApi.Dtos
{
    public class AttractionDto 
>>>>>>> remotes/origin/develop
    {
        public long AttractionId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
<<<<<<< HEAD

        public long LocationId { get; set; }
        public virtual LocationDto Location { get; set; }
        public bool Active { get; set; }

    }
}
=======
        // public long LocationId { get; set; }
        //public virtual Location Location { get; set; }
        public bool Active { get; set; }
    }
}
>>>>>>> remotes/origin/develop
