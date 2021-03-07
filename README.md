LocalizationSourceGenerator
===========================
This is source generator that creates localization class from xml file  
For example this xml:  
```xml
<Locale namespace="MyApp.Localization">
	<UI>
		<Text1>
		<Buttons>
			<CloseButton/>
		</Buttons>
	</UI>
	<Name/>
</Locale>
```  
will transformed to this c# code:  
```cs
namespace MyApp.Localization {
	public class Locale {
		
		public UI UI {get; set;}
		
		public string Name {get; set;}
		
	}
	public class UI {
		public string Text1 {get; set;}
		public Buttons Buttons {get; set;}
	}
	public class Buttons 
	{
		public string CloseButton {get; set;}
	}
}
```  
Usage
---------------------------

```xml
...
<ItemGroup>
	<!--template.xml is file that will be transformed to localization class-->
	<AdditionalFiles Include="template.xml"/>
</ItemGroup>
...
```
