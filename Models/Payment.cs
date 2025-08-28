using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } 
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
