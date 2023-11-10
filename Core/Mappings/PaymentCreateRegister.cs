public class SayingToSayingDtoRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // usage:
        // var paymentDto = payment.Adapt<PaymentDto>();
        config.NewConfig<Payment, PaymentDto>().PreserveReference(true);
    }
}
