﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Genre { get; set; }
        [Required]

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }


    }
}