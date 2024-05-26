using GymWebAPP.Models;

namespace GymWebAPP.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<UserGym> UserGyms { get; set; } = new List<UserGym>();
    }
}