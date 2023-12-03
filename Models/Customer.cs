namespace TP3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int membershipTypeId { get; set; }

        public MembershipType? MembershipType { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
