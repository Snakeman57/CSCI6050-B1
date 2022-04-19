using CineWeb.Data;

namespace CineWeb.Models
{
    public class Role
    {
        public string Id{get; set;}
         public string Roles { get; set; }
        public virtual ICollection<CineWebUser> Users { get; set; }

    }
}