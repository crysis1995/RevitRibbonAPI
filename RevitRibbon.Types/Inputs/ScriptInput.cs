namespace RevitRibbon.Types.Inputs
{
    public record AddScriptInput(string Name, string Tooltip = "");
#nullable enable
    public record UpdateScriptInput(int Id, string? Name = null, string? Tooltip = null);
#nullable disable
}