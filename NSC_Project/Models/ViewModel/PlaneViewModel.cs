namespace NSC_Project.Models.ViewModel
{
    public class PlaneViewModel
    {
        public string? search { get; set; }

        public string Oderby { get; set; }
        
        public List<Plane> Planes { get;set; }
        public Plane? Plane { get; set; }
    }
}
