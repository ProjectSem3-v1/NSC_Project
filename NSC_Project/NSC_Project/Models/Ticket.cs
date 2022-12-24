namespace NSC_Project.Models
{
    //Vé => Done
    public class Ticket
    {
        public int Id { get; set; }
        public bool Solded { get; set; } = false;
        //Giá vé
        public Fare Fare { get; set; }
        public int FareId { get; set; }

        //Chuyến Bay
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        //Ticket detail
        public int TicketDetailId { get; set; }
        public TicketDetail TicketDetail { get; set; }
        
    }
}
