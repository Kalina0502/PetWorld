﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Infrastructure.Data.Models
{
    public class GenderType
    {
        [Key]
        [Comment("GenderType identifier")]
        public int GenderId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}