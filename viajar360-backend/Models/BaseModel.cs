using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Comment("Fecha y hora de creación")]
        public DateTime CreatedDate { get; set; }

        [Comment("Fecha y hora de última actualización")]
        public DateTime UpdatedDate { get; set; }

        [Comment("Esto se implementa para soft delete")]
        public bool Active { get; set; }
    }
}

