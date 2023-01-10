namespace NSC_Project.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
