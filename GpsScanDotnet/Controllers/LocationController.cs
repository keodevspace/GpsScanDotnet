using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly TelegramService _telegramService;

    public LocationController(TelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] LocationData location)
    {
        _telegramService.SendLocation(location.Latitude, location.Longitude);
        return Ok(new { status = "enviado" });
    }
}

public class LocationData
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
