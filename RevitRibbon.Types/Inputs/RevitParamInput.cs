using RevitRibbon.Database.Models;

namespace RevitRibbon.Types.Inputs
{
    public record AddRevitParamInput(string Name, int ScriptId, ParamType ParamType = ParamType.Normal, string Description = "");
#nullable enable
    public record UpdateRevitParamInput(int Id, string? Name = null, int? ScriptId = null, ParamType? ParamType = null, string? Description = null);
#nullable disable
}