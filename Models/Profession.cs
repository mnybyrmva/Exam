namespace Studio.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team>? teams { get; set; }
    }
}
