namespace RevitRibbon.Types.Inputs
{
    public record AddGroupInput(string Name, bool IsNullable, string Type = null);
#nullable enable
    public record UpdateGroupInput(int Id, string? Name = null, bool? IsNullable = null, string? Type = null);
#nullable disable
}