using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookServicesApi.Models {
    public class Author {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(50)]
        public string FirstName {get; set;}

        [Required]
        [MaxLength(50)]
        public string LastName {get;set;}

        [Required]
        [MaxLength(50)]
        public string Gender {get; set;}

        [MaxLength(100)]
        public string Address {get;set;}

        [MaxLength(30)]
        public string City {get;set;}

        [MaxLength(2)]
        public string Province {get;set;}

        [MaxLength(10)]
        public string ZipCode {get; set;}

        [Phone]
        [MaxLength(20)]
        public string Phone {get;set;}

        [EmailAddress]
        [MaxLength(60)]
        public string Email {get;set;}

        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }


}
}

