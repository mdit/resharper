using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace MDIT.ReSharper.Macros
{
    /// <summary>
    /// Enables a text replacement to be made based on the name of the containing type.
    /// </summary>
    [MacroDefinition(
        "getContainingTypeNameWithTextReplacement",
        LongDescription = "Evaluates to short name of the most inner containing type with a text replacement.",
        ShortDescription = "Containing type name with text replace")]
    public class ContainingTypeNameWithTextReplacementMacroDef : SimpleMacroDefinition
    {
        /// <inheritdoc/>
        public override ParameterInfo[] Parameters { get; } =
        {
            new ParameterInfo(ParameterType.String), // oldValue
            new ParameterInfo(ParameterType.String), // newValue
        };
    }
}