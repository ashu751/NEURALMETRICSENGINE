using Microsoft.AspNetCore.Mvc;

using NeuralMetricsEngine.Models;
using NeuralMetricsEngine.Services;

namespace NeuralMetricsEngine.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetricsController : ControllerBase
{
    private readonly MetricsService _metricsService;

    public MetricsController(
        MetricsService metricsService)
    {
        _metricsService = metricsService;
    }

    [HttpPost("analyze")]
    public ActionResult<MetricsResponse> Analyze(
        [FromBody] GraphRequest request)
    {
        var result =
            _metricsService.Analyze(request);

        return Ok(result);
    }
}