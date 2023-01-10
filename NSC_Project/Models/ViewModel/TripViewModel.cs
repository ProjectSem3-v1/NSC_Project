namespace NSC_Project.Models.ViewModel
{
    public class TripViewModel
    {
        public List<AirportFrom> airportFroms { get; set; }
        public List<AirportTo> airportTos { get; set; }
        public List<TicketClass> ticketClasses { get; set; }
        public List<Ticket> tickets { get; set; }
        public List<AirlineCompany> airlineCompanies { get; set; }
        public DateTime TicketDate { get; set; } = DateTime.Now;
        public int people { get; set; }
        public int TicketClassId { get; set; }
        public int AirportToId { get; set; }
        public int AirportFromId { get; set; }
        public int AirlineCompanyId { get; set; }
        public double priceMax { get; set; }
        public double priceMin { get; set; }
        public int timeStartId { get; set; }
    }
}
