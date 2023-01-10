namespace NSC_Project.Models.ViewModel
{
    public class CheckoutViewModel
    {
        public Ticket ticket { get; set; }
        public int people { get; set; }
        public Customer? customer_1 { get; set; }
        public Customer? customer_2 { get; set; }
        public Customer? customer_3 { get; set; }
        public Customer? customer_4 { get; set; }
        public Customer? customer_5 { get; set; }
    }
}
