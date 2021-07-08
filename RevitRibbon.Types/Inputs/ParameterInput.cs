namespace RevitRibbon.Types.Inputs
{
    public record AddParameterInput(string Code, string Pl, string En, int GroupId, int RevitParamId);

#nullable enable
    public record UpdateParameterInput(string Code, string? Pl = null, string? En = null, int? GroupId = null, int? RevitParamId = null);
#nullable disable
}