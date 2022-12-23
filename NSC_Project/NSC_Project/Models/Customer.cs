namespace NSC_Project.Models
{
    //Khách hàng => Done
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CMND { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        //Hóa đơn
        public ICollection<Bill> Bills { get; set; }
        //Vé chuyến bay
        public ICollection<Ticket> Tickets { get; set; }
    }
}
