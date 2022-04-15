namespace CineWeb.Models
{
    public class Role
    {
        public string Id{get; set;}
         public string Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}