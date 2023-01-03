namespace NSC_Project.Models
{
    //Giá vé => Done
    public class Fare
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        //Chuyến bay
        public Trip? Trip { get; set; }
        public int TripId { get; set; }
        //Hạng vé
        public TicketClass? TicketClass { get; set; }
        public int TicketClassId { get; set; }
        //Vé chuyến bay
        public ICollection<Ticket>? Tickets { get; set; }  
        



    }
}
