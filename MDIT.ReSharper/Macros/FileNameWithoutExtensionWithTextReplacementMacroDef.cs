using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace MDIT.ReSharper.Macros
{
    /// <summary>
    /// Enables a text replacement to be made based on the name of the current file.
    /// </summary>
    [MacroDefinition("getFileNameWithTextReplacementWithoutExtension", LongDescription = "Evaluates current file name with a text replacement without extension", ShortDescription = "Current file name with text replacement without extension")]
    public class FileNameWithTextReplacementWithoutExtensionMacroDef : SimpleMacroDefinition
    {
        /// <inheritdoc/>
        public override ParameterInfo[] Parameters { get; } =
        {
            new ParameterInfo(ParameterType.String), // oldValue
            new ParameterInfo(ParameterType.String), // newValue
        };
    }
}