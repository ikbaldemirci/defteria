namespace Defteria.API.Models
{
    public class QrPayment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string QrCode { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
