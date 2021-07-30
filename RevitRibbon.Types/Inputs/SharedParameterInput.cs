using Autodesk.Revit.DB;
using System;

namespace RevitRibbon.Types.Inputs
{
    public record AddSharedParameterInput(
        string Name,
        int ScriptId,
        int SharedParameterGroupId,
        Autodesk.Revit.DB.ParameterType ParameterType,
        BuiltInParameterGroup BuiltInParameterGroup,
        BuiltInCategory[] BuiltInCategories,
        TextInputType TextInputType,
        string Description);
#nullable enable
    public record UpdateSharedParameterInput(
        Guid Id,
        string? Name = null,
        int? ScriptId = null,
        int? SharedParameterGroupId = null,
        Autodesk.Revit.DB.ParameterType? ParameterType = null,
        BuiltInParameterGroup? BuiltInParameterGroup = null,
        BuiltInCategory[]? BuiltInCategories = null,
        TextInputType? TextInputType = null,
        string? Description = null);
#nullable disable
}