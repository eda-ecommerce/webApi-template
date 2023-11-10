public interface IPaymentRepository
{
    Task<List<Payment>> GetAllPayments();
}

