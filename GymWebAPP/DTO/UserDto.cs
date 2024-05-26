//using GymWebAPP.Models;

namespace GymWebAPP.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        public ICollection<GymDto> Gyms { get; set; } = new List<GymDto>();
    }
}
