namespace NSC_Project.Models
{
    //Máy bay => Done
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
