[Route("api/Payments")]
[ApiController]
public class PaymentsController : ControllerBase
{

    private readonly ILogger<PaymentsController> _logger;
    private readonly IPaymentService _paymentService;

    public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService)
    {
        _logger = logger;
        _paymentService = paymentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        _logger.LogInformation($"Get payments request");

        List<PaymentDto> payments = null;
        payments = await _paymentService.GetPayments();

        return Ok(payments);
    }
}

