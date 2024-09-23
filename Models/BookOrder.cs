using System.ComponentModel.DataAnnotations;

namespace BookServicesApi.Models {
    public class BookOrder {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Foreign key to Book
        [Required]
        public int BookId { get; set; }

        // Navigation property to the related Book
        public Book Book { get; set; }
    }
}