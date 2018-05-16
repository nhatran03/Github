﻿using Github.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Github.ViewModels
{
	public class GigFormViewModel
    {
        [Required]
        public string Vanue { get; set; }

        [Required]
        
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        [Required]
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
                
    }
}