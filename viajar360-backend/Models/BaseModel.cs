using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Viajar360Api.Models
{
    public class BaseModel
    {
        [Comment("Fecha y hora de creación")]
        public DateTime CreatedDate { get; set; }

        [Comment("Fecha y hora de última actualización")]
        public DateTime UpdatedDate { get; set; }

        [Comment("Esto se implementa para soft delete")]
        public bool Active { get; set; }
    }
}

