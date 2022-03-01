using System;
using System.ComponentModel;
using System.Reflection;

// Token: 0x02004B75 RID: 19317
public static class DHelper
{
	// Token: 0x0601C6AC RID: 116396 RVA: 0x0089E6F0 File Offset: 0x0089CAF0
	public static string GetDescription(this Enum value, bool nameInstead = true)
	{
		Type type = value.GetType();
		string name = Enum.GetName(type, value);
		if (name == null)
		{
			return null;
		}
		FieldInfo field = type.GetField(name);
		DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
		if (descriptionAttribute == null && nameInstead)
		{
			return name;
		}
		return (descriptionAttribute != null) ? descriptionAttribute.Description : null;
	}

	// Token: 0x0601C6AD RID: 116397 RVA: 0x0089E754 File Offset: 0x0089CB54
	public static string[] GetDescriptions(this Type type)
	{
		string[] names = Enum.GetNames(type);
		if (names == null)
		{
			return null;
		}
		for (int i = 0; i < names.Length; i++)
		{
			FieldInfo field = type.GetField(names[i]);
			DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			if (descriptionAttribute != null)
			{
				names[i] = descriptionAttribute.Description;
			}
		}
		return names;
	}

	// Token: 0x0601C6AE RID: 116398 RVA: 0x0089E7B4 File Offset: 0x0089CBB4
	public static Array GetValues(this Type type)
	{
		return Enum.GetValues(type);
	}
}
