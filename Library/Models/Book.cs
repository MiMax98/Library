using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Title { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Autor jest wymagany")]
        public string Author { get; set; }

        [DisplayName("Rok")]
        [Required(ErrorMessage = "Rok jest wymagany")]
        public int Year { get; set; }

        public List<Order> Orders { get; set; }
    }
}
