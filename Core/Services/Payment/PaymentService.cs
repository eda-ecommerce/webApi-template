public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(ILogger<PaymentService> logger, IPaymentRepository paymentRepository)
    {
        _logger = logger;
        _paymentRepository = paymentRepository;

    }

    public async Task<List<PaymentDto>?> GetPayments()
    {
        var payments = await _paymentRepository.GetAllPayments();

        if (payments == null)
        {
            return null;
        }

        var paymentDto = payments.Adapt<List<PaymentDto>>();

        return paymentDto;
    }

    public async Task<PaymentDto?> GetPayment(Guid paymentId)
    {
        var payment = await _paymentRepository.GetPayment(paymentId);

        if (payment == null)
        {
            return null;
        }

        // Map to Dto
        var paymentDto = payment.Adapt<PaymentDto>();

        return paymentDto;
    }

    public async Task UpdatePayment(PaymentUpdateDto paymentUpdateDto)
    {
        var payment = await _paymentRepository.GetPayment((Guid)paymentUpdateDto.UserId);

        if (payment == null)
        {
            throw new Exception($"Payment not found: {paymentUpdateDto.UserId}");
        }

        payment.Firstname = paymentUpdateDto.Firstname;
        payment.Lastname = paymentUpdateDto.Lastname;
        payment.Username = paymentUpdateDto.Username;

        await _paymentRepository.UpdatPayment(payment);
    }
}

