﻿using System.ComponentModel.DataAnnotations;

namespace first2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; } = new List<Book>();

    }
}
