using RevitRibbon.Database.Models;

namespace RevitRibbon.Types.Inputs
{
    public record AddRevitParamInput(string Name, int ScriptId, ParamType ParamType = ParamType.Normal, string Description = "");
}