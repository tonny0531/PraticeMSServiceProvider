namespace ServiceProviderTest.Services;

public interface IServiceB
{
    string GetServiceName();
}

public class ServiceB: IServiceB
{
    private readonly ILogger<ServiceB> _logger;
    private readonly IServiceProvider _sp;
    
    public ServiceB(IServiceProvider sp, ILogger<ServiceB> logger)
    {
        _logger = logger;
        _sp = sp;
        _sp.GetService<IServiceA>();
    }
    
    public string GetServiceName()
    {
        _sp.GetService<IServiceA>();

        _logger.LogInformation("ServiceB Log");   
        return nameof(ServiceB);
    }
}