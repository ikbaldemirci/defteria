namespace Defteria.API.Models
{
    public class TopUp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
