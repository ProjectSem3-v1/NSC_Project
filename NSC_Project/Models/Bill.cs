namespace NSC_Project.Models
{
    //Hóa đơn => Done
    public class Bill
    {
        public int Id { get; set; }
        //Khách hàng
        public User? User { get; set; }
        public int UserId { get; set; }
        //Ngày đặt
        public DateTime CreatedAt { get; set; }
        //Thành tiền
        public double Subtotal { get; set; }
        //Vé máy bay
        public ICollection<TicketDetail>? TicketDetails { get; set; }
        
    }
}
