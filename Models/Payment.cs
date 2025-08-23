using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
