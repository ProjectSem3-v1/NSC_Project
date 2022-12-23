namespace NSC_Project.Models
{
    //Vé => Done
    public class Ticket
    {
        public int Id { get; set; }
        //Chuyến Bay
        public int TripId { get; set; }

        public Trip Trip { get; set; }
        //Khách hàng
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        //Hóa đơn
        public Bill Bill { get; set; }
        public int BillId { get; set; }
        //Giá vé
        public Fare Fare { get; set; }
        public int FareId { get; set;}


    }
}
