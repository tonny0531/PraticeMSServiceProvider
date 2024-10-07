namespace ServiceProviderTest.Services;

public interface IServiceA
{
    string GetServiceName();
}

public class ServiceA: IServiceA
{
    private readonly ILogger<ServiceB> _logger;
    private readonly IServiceProvider _sp;

    public ServiceA(IServiceProvider sp, ILogger<ServiceB> logger)
    {
        _sp = sp;
        _logger = logger;
    }
    
    public string GetServiceName()
    {
        _sp.GetService<IServiceB>();

        _logger.LogInformation("ServiceA Log");   
        return nameof(ServiceA);
    }
}