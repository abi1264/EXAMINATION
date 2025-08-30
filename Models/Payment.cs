using EXAMINATION.Models.Enum;
using System.ComponentModel.DataAnnotations;
namespace EXAMINATION.Models

{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public User? User { get; set; }
        [Required]
        public double Amount { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        [Required]
        public string TransactionId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
