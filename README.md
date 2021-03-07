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
		
		public UIClass UI {get; set;}
		
		public string Name {get; set;}
		
		public class UIClass {
			public string Text1 {get; set;}
			public ButtonsClass Buttons {get; set;}
		}
		public class Buttons 
		{
			public string CloseButton {get; set;}
		}
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