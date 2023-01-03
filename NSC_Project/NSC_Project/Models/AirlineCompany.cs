namespace NSC_Project.Models
{
    //Hãng máy bay => Done
    public class AirlineCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<Trip>? Trips { get; set; }
    }
}
