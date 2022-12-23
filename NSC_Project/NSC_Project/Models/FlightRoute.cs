namespace NSC_Project.Models
{
    //Tuyến bay => Done
    public class FlightRoute
    {
        public int Id { get; set; }
        public int AirportFromId { get; set; } 
        public int AirportToId { get; set; }
        public AirportFrom AirportFrom { get; set; }
        public AirportTo AirportTo { get; set; }
        public ICollection<Trip> Trips { get; set; }

    }
}
