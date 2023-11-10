public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDbContext _context;

    public PaymentRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllPayments()
    {
        var payments = await _context.Payments
            .ToListAsync();

        return payments;
    }
}

