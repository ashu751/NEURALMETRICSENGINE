# NeuralMetricsEngine

Live Metrics Update Engine for a Visual AI Model Builder Platform built using ASP.NET Core Web API and C#.

This project is a backend metrics analysis engine designed for a drag-and-drop neural network workflow editor. The service receives neural network graph JSON from the frontend and computes real-time architecture analytics such as:

* Total Trainable Parameters
* Estimated Memory Usage
* FLOPs (Floating Point Operations)
* Model Complexity Classification

---

# Project Motivation

The project was inspired by the UI wireframe and technical architecture of a no-code/low-code Visual AI Development Platform.

The goal of the metrics engine is to provide real-time feedback while users visually design neural network architectures on a canvas.

This backend service powers the top-right "Live Metrics Update" panel from the platform wireframe.

---

# Features

## Current Features

* ASP.NET Core Web API backend
* Swagger UI integration
* Neural network parameter analysis
* Memory usage estimation
* FLOPs approximation
* Model complexity classification
* JSON-based graph architecture input
* Modular backend architecture

---

# Supported Layer Types

Currently supported:

* Dense Layer
* Conv2D Layer
* Embedding Layer

More layer types can easily be added later.

---

# Mathematical Formulas Used

## Dense Layer Parameters

```txt
P_dense = (N_in × N_out) + N_out
```

Where:

* N_in = input neurons
* N_out = output neurons

---

## Conv2D Parameters

```txt
P_conv = ((K_h × K_w × C_in) + 1) × C_out
```

Where:

* K_h = kernel height
* K_w = kernel width
* C_in = input channels
* C_out = output channels

---

## FLOPs Estimation

```txt
FLOPs = 2 × N_in × N_out
```

---

## Memory Estimation

Assuming float32 precision:

```txt
1 parameter = 4 bytes
```

```txt
Memory(MB) = (Parameters × 4) / (1024 × 1024)
```

---

# Tech Stack

| Technology   | Purpose              |
| ------------ | -------------------- |
| C#           | Programming Language |
| ASP.NET Core | Backend Framework    |
| Swagger      | API Testing UI       |
| REST API     | Communication Layer  |
| JSON         | Graph Serialization  |

---

# Project Structure

```txt
NeuralMetricsEngine/
│
├── Controllers/
│   └── MetricsController.cs
│
├── Models/
│   ├── GraphRequest.cs
│   ├── MetricsResponse.cs
│   └── Node.cs
│
├── Services/
│   └── MetricsService.cs
│
├── Program.cs
│
└── appsettings.json
```

---

# File Explanations

## Controllers/MetricsController.cs

Responsible for exposing REST API endpoints.

Main endpoint:

```txt
POST /api/Metrics/analyze
```

This endpoint:

1. receives graph JSON
2. forwards request to MetricsService
3. returns computed metrics

---

## Models/Node.cs

Represents a neural network layer node.

Contains:

* layer type
* layer parameters

Example:

```json
{
  "type": "Dense",
  "parameters": {
    "input": 128,
    "output": 256
  }
}
```

---

## Models/GraphRequest.cs

Represents the full graph architecture received from the frontend.

Contains:

* list of neural network nodes

---

## Models/MetricsResponse.cs

Represents the analytics returned by the backend.

Contains:

* totalParameters
* memoryMB
* flops
* complexity

---

## Services/MetricsService.cs

Core neural network analysis engine.

Responsible for:

* parameter calculations
* memory estimation
* FLOPs computation
* complexity analysis

This is the primary backend business logic layer.

---

## Program.cs

Application startup configuration.

Responsible for:

* dependency injection
* Swagger setup
* controller mapping
* application middleware

---

# API Endpoint

## POST

```txt
/api/Metrics/analyze
```

---

# Example Request

```json
{
  "nodes": [
    {
      "type": "Dense",
      "parameters": {
        "input": 784,
        "output": 128
      }
    },
    {
      "type": "Dense",
      "parameters": {
        "input": 128,
        "output": 10
      }
    },
    {
      "type": "Conv2D",
      "parameters": {
        "in_channels": 3,
        "out_channels": 64,
        "kernel_size": 3
      }
    }
  ]
}
```

---

# Example Response

```json
{
  "totalParameters": 103562,
  "memoryMB": 0.4,
  "flops": 205568,
  "complexity": "Low"
}
```

---

# How To Run The Project

## Step 1 — Install .NET SDK

Download and install:

https://dotnet.microsoft.com/download

Recommended:

* .NET 8 SDK

Verify installation:

```bash
dotnet --version
```

---

## Step 2 — Clone Repository

```bash
git clone <your-repository-url>
```

Go inside project:

```bash
cd NeuralMetricsEngine
```

---

## Step 3 — Restore Packages

```bash
dotnet restore
```

---

## Step 4 — Run Application

```bash
dotnet run
```

You should see:

```txt
Now listening on:
http://localhost:5221
```

---

## Step 5 — Open Swagger UI

Open browser:

```txt
http://localhost:5221/swagger
```

Swagger provides:

* API testing interface
* request/response visualization
* endpoint documentation

---

# How To Test API

## Step 1

Open:

```txt
POST /api/Metrics/analyze
```

---

## Step 2

Click:

* Try it out

---

## Step 3

Paste example JSON request.

---

## Step 4

Click:

* Execute

The backend will compute:

* parameters
* memory usage
* FLOPs
* complexity

in real time.

---

# Future Improvements

Planned extensions:

* Transformer layer support
* LSTM metrics
* Tensor shape propagation
* SignalR live updates
* GPU memory estimation
* Tensor validation engine
* Architecture optimization suggestions
* ONNX support
* Real-time workflow synchronization

---

# Research & Learning Goals

This project was developed as part of research into:

* Visual AI Development Platforms
* Neural Network Infrastructure
* AI Workflow Systems
* Real-Time Architecture Analytics
* Backend Engineering using ASP.NET Core

---

# Inspiration

Inspired by:

* ComfyUI
* n8n
* TensorFlow Playground
* FlowiseAI
* Visual node-based workflow systems

---


Ashutosh Kumar Singh


