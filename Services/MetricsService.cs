using NeuralMetricsEngine.Models;

namespace NeuralMetricsEngine.Services;

public class MetricsService
{
    public MetricsResponse Analyze(GraphRequest request)
    {
        long totalParameters = 0;
        long totalFlops = 0;

        foreach (var node in request.Nodes)
        {
            switch (node.Type)
            {
                case "Dense":
                    {
                        int input =
                            node.Parameters["input"];

                        int output =
                            node.Parameters["output"];

                        long parameters =
                            (input * output) + output;

                        totalParameters += parameters;

                        totalFlops +=
                            2L * input * output;

                        break;
                    }

                case "Conv2D":
                    {
                        int inChannels =
                            node.Parameters["in_channels"];

                        int outChannels =
                            node.Parameters["out_channels"];

                        int kernelSize =
                            node.Parameters["kernel_size"];

                        long parameters =
                            ((kernelSize * kernelSize
                            * inChannels) + 1)
                            * outChannels;

                        totalParameters += parameters;

                        totalFlops +=
                            parameters * 2;

                        break;
                    }

                case "Embedding":
                    {
                        int vocabSize =
                            node.Parameters["vocab_size"];

                        int embeddingDim =
                            node.Parameters["embedding_dim"];

                        long parameters =
                            vocabSize * embeddingDim;

                        totalParameters += parameters;

                        totalFlops += parameters;

                        break;
                    }
            }
        }

        double memoryMB =
            (totalParameters * 4.0)
            / (1024 * 1024);

        string complexity =
            totalParameters switch
            {
                < 1_000_000 => "Low",
                < 10_000_000 => "Medium",
                _ => "High"
            };

        return new MetricsResponse
        {
            TotalParameters = totalParameters,

            MemoryMB =
                Math.Round(memoryMB, 2),

            FLOPs = totalFlops,

            Complexity = complexity
        };
    }
}