namespace Defteria.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal LimitAmount { get; set; }
    }
}
