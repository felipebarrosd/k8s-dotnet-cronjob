using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker iniciado");

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

            _logger.LogInformation("Tarefa concluída com sucesso.");
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            Environment.Exit(1); 
        }

        Environment.Exit(0); 
    }
}

