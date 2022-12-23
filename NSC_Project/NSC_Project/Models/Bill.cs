namespace NSC_Project.Models
{
    //Hóa đơn => Done
    public class Bill
    {
        public int Id { get; set; }
        //Khách hàng
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        //Ngày đặt
        public int CreatedAt { get; set; }
        //Thành tiền
        public double Subtotal { get; set; }
        //Vé máy bay
        public ICollection<Ticket> Ticket { get; set; }
        
    }
}
