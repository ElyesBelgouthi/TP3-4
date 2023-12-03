namespace TP3.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public double SignUpFee { get; set; }

        public int DurationInMonth;
        public double DiscountRate{ get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
