using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace LocalizationSourceGenerator
{
    public class XmlLocalizationGenerator : ILocalizationGenerator
    {
        private List<string> classes = new();
        public string GenerateLocalization(string template)
        {

            XmlDocument document = new XmlDocument();
            document.LoadXml(template);
            string namespaceName = document.DocumentElement.GetAttribute("namespace") ?? "Localization";
            var sb = new StringBuilder();
            GenClass(document.DocumentElement);
            sb.AppendLine($"namespace {namespaceName}\n{{");
			
			foreach(var item in classes) 
			{
				sb.AppendLine(item);
			}
			
            sb.Append('}');

            return sb.ToString();
        }
        private void GenClass(XmlNode element)
        {
            var sb = new StringBuilder();
            sb.Append("public class ");
            sb.Append(element.Name);
            sb.AppendLine("{");
            foreach (XmlNode item in element.ChildNodes)
            {
                if (item.ChildNodes.Count == 0)
                {
                    sb.AppendLine($"public string {item.Name} {{get; set;}}");
                }
                else if (item.ChildNodes.Count == 1 && item.FirstChild.NodeType == XmlNodeType.Text)
                {
                    sb.AppendLine($"public string {item.Name} {{get; set;}}");
                }
                else
                {
                    sb.AppendLine($"public {item.Name} {item.Name} {{get; set;}}");
                    GenClass(item); 
                }
            } 
            sb.AppendLine("}");
            classes.Add(sb.ToString());
        }
    }
}
