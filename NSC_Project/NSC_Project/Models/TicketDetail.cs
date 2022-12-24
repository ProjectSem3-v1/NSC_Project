namespace NSC_Project.Models
{
    public class TicketDetail
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        //Khách hàng
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        //Hóa đơn
        public Bill Bill { get; set; }
        public int BillId { get; set; }
    }
}
