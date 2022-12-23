namespace NSC_Project.Models
{
    //Hạng vé => Done
    public class TicketClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Fare> Fares { get; set;}

    }
}
