namespace Library.Models
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel(Book book, List<Student> students)
        {
            Book = book;
            Students = students;
        }

        public Book Book { get; set; }
        public List<Student> Students { get; set; }
    }
}
