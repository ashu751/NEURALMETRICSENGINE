namespace NeuralMetricsEngine.Models;

public class MetricsResponse
{
    public long TotalParameters { get; set; }

    public double MemoryMB { get; set; }

    public long FLOPs { get; set; }

    public string Complexity { get; set; } = string.Empty;
}