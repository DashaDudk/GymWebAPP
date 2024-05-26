using System.Data;
using GymWebAPP.Models;

namespace GymWebAPP.Models
{
    public class Gym
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int StatusId { get; set; }

        public DateTime DateTime { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public virtual Status Status { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<UserGym> UserGyms { get; set; } = new List<UserGym>();
    }
}

