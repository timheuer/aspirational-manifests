using AspireRabbit = Aspirate.Contracts.Models.AspireManifests.Components.V0.RabbitMq;

namespace Aspirate.Cli.Processors.Components.RabbitMQ;

/// <summary>
/// Handles producing the RabbitMq component as Kustomize manifest.
/// </summary>
public class RabbitMqProcessor(IFileSystem fileSystem, IAnsiConsole console) : BaseProcessor<RabbitMqTemplateData>(fileSystem, console)
{
    private readonly IReadOnlyCollection<string> _manifests =
    [
        $"{TemplateLiterals.RabbitMqType}.yml",
    ];

    /// <inheritdoc />
    public override string ResourceType => AspireLiterals.RabbitMq;

    /// <inheritdoc />
    public override Resource? Deserialize(ref Utf8JsonReader reader) =>
        JsonSerializer.Deserialize<AspireRabbit>(ref reader);

    public override Task<bool> CreateManifests(KeyValuePair<string, Resource> resource, string outputPath, AspirateSettings? aspirateSettings = null)
    {
        var resourceOutputPath = Path.Combine(outputPath, resource.Key);

        EnsureOutputDirectoryExistsAndIsClean(resourceOutputPath);

        var data = new RabbitMqTemplateData(_manifests);

        CreateCustomManifest(resourceOutputPath, $"{TemplateLiterals.RabbitMqType}.yml", TemplateLiterals.RabbitMqType, data, aspirateSettings);
        CreateComponentKustomizeManifest(resourceOutputPath, data, aspirateSettings);

        LogCompletion(resourceOutputPath);

        return Task.FromResult(true);
    }
}
