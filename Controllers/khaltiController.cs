
using EXAMINATION.Models.Khalti;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class KhaltiController : ControllerBase
{
    private readonly KhaltiService _khalti;
    public KhaltiController(KhaltiService khalti)
    {
        _khalti = khalti;
    }

    [HttpPost("initiate")]
    public async Task<IActionResult> InitiatePayment([FromBody] KhaltiInitiateRequest request)
    {
        var response = await _khalti.InitiatePaymentAsync(request);
        return Ok(response);
    }

    [HttpPost("lookup")]
    public async Task<IActionResult> LookupPayment([FromBody] KhaltiLookupRequest request)
    {
        var response = await _khalti.LookupPaymentAsync(request.pidx);
        return Ok(response);
    }
}
