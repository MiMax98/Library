namespace Library.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Returned { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
