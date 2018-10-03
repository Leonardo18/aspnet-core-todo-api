namespace TodoApi.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Author { get; set; }
    }
}