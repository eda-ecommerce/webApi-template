public  interface IPaymentService
{
    Task<List<PaymentDto>?> GetPayments();
}

