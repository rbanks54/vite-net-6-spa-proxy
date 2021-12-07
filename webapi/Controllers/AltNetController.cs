namespace webapi.Controllers.Mine;

[ApiController]
[Route("[controller]")]
public class AltNetController : ControllerBase
{
  public AltNetController(ILogger<AltNetController> logger)
  {
    Logger = logger;
  }

  public ILogger<AltNetController> Logger { get; }

  [HttpGet("/api/altnet")]
    public IActionResult Get()
    {
      var x = DateTime.UtcNow.Second;
      var evenSecond = (x % 2 == 0);
      //if (evenSecond) return NotFound("No!");
      return Ok("/alt/net");
    }

  [HttpGet("/objects")]
  public ICollection<MyObject> GetObjects()
  {
    var c = new List<MyObject>();
    c.Add(new MyObject(3,"first"));
    c.Add(new(2,"second"));

    return c;
  }
}

public record struct MyObject(int Value, string MyObjectName);

[JsonSerializable(typeof(ICollection<MyObject>))]
internal partial class SourceGenerationContext: JsonSerializerContext {}