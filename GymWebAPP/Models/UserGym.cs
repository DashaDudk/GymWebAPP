using GymWebAPP.Models;

namespace GymWebAPP.Models
{
    public class UserGym
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
