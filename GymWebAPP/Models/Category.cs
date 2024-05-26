using System.ComponentModel.DataAnnotations;
using GymWebAPP.Models;

namespace GymWebAPP.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Категорія")]

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Gym> Gyms { get; set; } = new List<Gym>();
    }
}