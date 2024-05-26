namespace GymWebAPP.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<GymDto> Gyms { get; set; } = new List<GymDto>();
    }
}
