using System.ComponentModel;

namespace Library.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [DisplayName("Klasa")]
        public int Grade { get; set; }
    }
}
