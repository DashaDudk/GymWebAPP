namespace GymWebAPP.DTO
{
    public class GymDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}
