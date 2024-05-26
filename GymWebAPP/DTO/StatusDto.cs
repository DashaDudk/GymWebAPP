using System.Collections.Generic;

namespace GymWebAPP.DTO
{
    public class StatusDto
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public ICollection<GymDto> Gyms { get; set; } = new List<GymDto>();
    }
}