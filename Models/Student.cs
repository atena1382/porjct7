namespace WebApplication1.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Lesson { get; set; } = string.Empty;
        public double Grade  { get; set; }
    }
}
