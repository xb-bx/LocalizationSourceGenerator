using Microsoft.CodeAnalysis;
using System;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using Microsoft.CodeAnalysis.Diagnostics;

namespace LocalizationSourceGenerator
{

    [Generator]
    public class LocalizationSourceGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        { 
            var templateFile = context.AdditionalFiles.FirstOrDefault(x => Path.GetExtension(x.Path) == ".xml")?.Path;
            if (!string.IsNullOrWhiteSpace(templateFile))
            {
                ILocalizationGenerator generator = new XmlLocalizationGenerator();
                var s = generator.GenerateLocalization(File.ReadAllText(templateFile));
                context.AddSource("Localization",s );
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
