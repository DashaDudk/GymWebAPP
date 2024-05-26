using System.ComponentModel.DataAnnotations;
using GymWebAPP.Models;

namespace GymWebAPP.Models
{
    public class Status
    {
        public Status()
        {
            Gyms = new List<Gym>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Статус")]

        public string StatusName { get; set; } = null!;

        public virtual ICollection<Gym> Gyms { get; set; } = new List<Gym>();
    }
}

