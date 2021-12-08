using System.Runtime.InteropServices;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.ReSharper.Psi;

namespace MDIT.ReSharper.Macros
{
    /// <summary>
    /// Enables a text replacement to be made based on the name of the current file.
    /// </summary>
    [MacroImplementation(Definition = typeof(FileNameWithTextReplacementWithoutExtensionMacroDef), ScopeProvider = typeof(PsiImpl))]
    public class FileNameWithTextReplacementWithoutExtensionMacroImpl : SimpleMacroImplementation
    {
        private readonly IMacroParameterValueNew _oldValueParameter;
        private readonly IMacroParameterValueNew _newValueParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameWithTextReplacementWithoutExtensionMacroImpl"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public FileNameWithTextReplacementWithoutExtensionMacroImpl([Optional] MacroParameterValueCollection arguments)
        {
            if (arguments != null && arguments.Count > 1)
            {
                _oldValueParameter = arguments[0];
                _newValueParameter = arguments[1];
            }
        }

        /// <inheritdoc/>
        public override HotspotItems GetLookupItems(IHotspotContext context)
        {
            if (_oldValueParameter == null || _newValueParameter == null)
            {
                return null;
            }

            var psiSourceFile = context.ExpressionRange.Document.GetPsiSourceFile(context.SessionContext.Solution);
            var fileNameWithoutExtension = psiSourceFile?.GetLocation().NameWithoutExtension;
            if (fileNameWithoutExtension == null)
            {
                return null;
            }

            return MacroUtil.SimpleEvaluateResult(fileNameWithoutExtension.Replace(_oldValueParameter.GetValue(), _newValueParameter.GetValue()));
        }
    }
}