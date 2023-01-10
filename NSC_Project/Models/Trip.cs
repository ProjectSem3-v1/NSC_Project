namespace NSC_Project.Models
{
    //Chuyến bay => Done
    public class Trip
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public double FlightTime { get; set; }
        public int Status { get; set; }
        //Máy bay
        public Plane? Plane { get; set; }
        public int PlaneId { get; set; }
        //Tuyến bay
        public FlightRoute? FlightRoute { get; set; }
        public int FlightRouteId { get; set; }
        //Hãng bay
        public AirlineCompany? AirlineCompany { get; set; }
        public int AirlineCompanyId { get; set; }
        //Vé chuyến bay
        public ICollection<Ticket>? Tickets { get; set; } 
        //Giá vé chuyến bay
        public ICollection<Fare>? Fares { get; set; }

    }
}
