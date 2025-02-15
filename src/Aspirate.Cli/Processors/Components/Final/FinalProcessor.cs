namespace Aspirate.Cli.Processors.Components.Final;

/// <summary>
/// A project component for version 0 of Aspire.
/// </summary>
public class FinalProcessor(IFileSystem fileSystem, IAnsiConsole console) : BaseProcessor<FinalTemplateData>(fileSystem, console)
{

    /// <inheritdoc />
    public override string ResourceType => AspireLiterals.Final;

    /// <inheritdoc />
    public override Resource Deserialize(ref Utf8JsonReader reader) =>
        throw new NotImplementedException();

    public void CreateFinalManifest(Dictionary<string, Resource> resources, string outputPath, AspirateSettings? aspirateSettings = null)
    {
        var manifests = resources.Select(x => x.Key).ToList();

        var templateData = new FinalTemplateData(manifests);

        CreateComponentKustomizeManifest(outputPath, templateData, aspirateSettings);
    }
}
