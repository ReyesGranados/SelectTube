using Microsoft.AspNetCore.Mvc;

public class MyController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public MyController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public string Get()
    {
        var variable1 = _configuration.GetValue<string>("Development:Variable1");
        var variable2 = _configuration.GetValue<string>("Production:Variable2");
        
        
            return "Hello world";
        
        // ...
    }
}

