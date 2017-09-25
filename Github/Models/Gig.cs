﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Github.Models
{
    public class Gig
    {
        public int Id { get; set; }
        
        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime Datetime { get; set; }
        [Required]
        [StringLength(255)]
        public string Vanue { get; set; }
        
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

    }


}