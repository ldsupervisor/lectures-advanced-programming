using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();

[McpServerToolType]
public static class LectureTools
{
    [McpServerTool]
    [Description("Returning topic of the current lecture")]
    public static string GetLecture(
        [Description("Number of lecture from 1 to 5")] int number)
    {
        return number switch
        {
            1 => "Introduction to C# and .NET",
            2 => "Classes and Interfaces",
            3 => "LINQ and Collections",
            4 => "Async and await",
            5 => "Communication with APIs",
            _ => "Lecture is not found."
        };
    }
}