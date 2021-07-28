using System;

namespace RevitRibbon.Types.Inputs
{
    public record AddParameterInput(string Code, string Pl, string En, int GroupId, Guid SharedParameterId);
#nullable enable
    public record UpdateParameterInput(string Code, string? Pl = null, string? En = null, int? GroupId = null, Guid? SharedParameterId = null);
#nullable disable
}