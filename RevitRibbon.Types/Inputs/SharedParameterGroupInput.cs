namespace RevitRibbon.Types.Inputs
{
    public record AddSharedParameterGroupInput(string Name);
#nullable enable
    public record UpdateSharedParameterGroupInput(int Id, string? Name = null);
#nullable disable
}