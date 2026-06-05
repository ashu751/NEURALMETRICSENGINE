namespace NeuralMetricsEngine.Models;

public class Node
{
    public string Type { get; set; } = string.Empty;

    public Dictionary<string, int> Parameters { get; set; } = new();
}