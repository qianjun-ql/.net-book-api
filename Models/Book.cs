using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BookServicesApi.Models {
    public class Book {
        [Key]
        public int Id {get;set;}

        [Required]
        [MaxLength(100)]
        public string Title {get;set;}

        [Required]
        [MaxLength(13)]
        public string ISBN {get;set;}

        [Required]
        // Valid year for books
        [Range(1500, 2100)]
        public int Year {get;set;}

        [Required]
        [Range(0.01, 10000.00)]
        public float Price {get;set;}

        [Required]
        [MaxLength(30)]
        public string Genre {get;set;}

        [Required]
        public int AuthorId {get;set;}
    }
}