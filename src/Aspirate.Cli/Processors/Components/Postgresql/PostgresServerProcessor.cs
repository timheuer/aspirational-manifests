namespace Aspirate.Cli.Processors.Components.Postgresql;

/// <summary>
/// Handles producing the Postgres component as Kustomize manifest.
/// </summary>
public class PostgresServerProcessor(IFileSystem fileSystem, IAnsiConsole console) : BaseProcessor<PostgresServerTemplateData>(fileSystem, console)
{
    private readonly IReadOnlyCollection<string> _manifests =
    [
        $"{TemplateLiterals.PostgresServerType}.yml",
    ];

    /// <inheritdoc />
    public override string ResourceType => AspireLiterals.PostgresServer;

    /// <inheritdoc />
    public override Resource? Deserialize(ref Utf8JsonReader reader) =>
        JsonSerializer.Deserialize<PostgresServer>(ref reader);

    public override Task<bool> CreateManifests(KeyValuePair<string, Resource> resource, string outputPath, AspirateSettings? aspirateSettings = null)
    {
        var resourceOutputPath = Path.Combine(outputPath, resource.Key);

        EnsureOutputDirectoryExistsAndIsClean(resourceOutputPath);

        var data = new PostgresServerTemplateData(_manifests);

        CreateCustomManifest(resourceOutputPath, $"{TemplateLiterals.PostgresServerType}.yml", TemplateLiterals.PostgresServerType, data, aspirateSettings);
        CreateComponentKustomizeManifest(resourceOutputPath, data, aspirateSettings);

        LogCompletion(resourceOutputPath);

        return Task.FromResult(true);
    }
}
