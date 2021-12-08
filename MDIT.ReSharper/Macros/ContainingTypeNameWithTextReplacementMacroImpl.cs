using System.Runtime.InteropServices;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;

namespace MDIT.ReSharper.Macros
{
    /// <summary>
    /// Enables a text replacement to be made based on the name of the containing type.
    /// </summary>
    [MacroImplementation(Definition = typeof(ContainingTypeNameWithTextReplacementMacroDef), ScopeProvider = typeof(PsiImpl))]
    public class ContainingTypeNameWithTextReplacementMacroImpl : SimpleMacroImplementation
    {
        private readonly IMacroParameterValueNew _oldValueParameter;
        private readonly IMacroParameterValueNew _newValueParameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainingTypeNameWithTextReplacementMacroImpl"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public ContainingTypeNameWithTextReplacementMacroImpl([Optional] MacroParameterValueCollection arguments)
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
            if (psiSourceFile == null)
            {
                return null;
            }

            using (ReadLockCookie.Create())
            {
                context.SessionContext.Solution.GetPsiServices().Files.CommitAllDocuments();
                var primaryPsiFile = psiSourceFile.GetPrimaryPsiFile();
                if (primaryPsiFile == null)
                {
                    return null;
                }

                var (startOffset, _) = primaryPsiFile.Translate(context.ExpressionRange);
                if (!(primaryPsiFile.FindTokenAt(startOffset) is ITokenNode tokenAt))
                {
                    return null;
                }

                var containingNode = tokenAt.GetContainingNode<ITypeDeclaration>();
                if (containingNode == null)
                {
                    return null;
                }

                var className = containingNode.DeclaredName;
                return MacroUtil.SimpleEvaluateResult(className.Replace(_oldValueParameter.GetValue(), _newValueParameter.GetValue()));
            }
        }
    }
}