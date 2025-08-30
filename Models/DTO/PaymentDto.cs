using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class PaymentDto
    {
      
        public int? UserId { get; set; }
      
        public double? Amount { get; set; }
        public PaymentStatus? Status { get; set; }
        public string? TransactionId { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
