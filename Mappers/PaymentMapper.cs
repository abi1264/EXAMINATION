using EXAMINATION.Models;
using EXAMINATION.Models.DTO;

namespace EXAMINATION.Mappers
{
    static public class PaymentMapper
    {
        static public void ApplyPatch(PaymentDto updatePayment, Payment payment)
        {

            if (updatePayment.UserId != null)
            {
                payment.UserId = updatePayment.UserId.Value;
            }
            if (updatePayment.Amount != null)
            {

                payment.Amount = updatePayment.Amount.Value;
            }
            if (updatePayment.Status != null)
            {
                payment.Status = updatePayment.Status.Value;
            }
            if (updatePayment.TransactionId != null)
            {
                payment.TransactionId = updatePayment.TransactionId;
            }
            if (updatePayment.CreatedAt != null)
            {
                payment.CreatedAt = updatePayment.CreatedAt.Value;
            }
        }
    }
}
