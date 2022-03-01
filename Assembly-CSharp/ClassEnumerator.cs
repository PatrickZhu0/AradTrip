using System;
using System.Reflection;
using UnityEngine;

// Token: 0x0200010A RID: 266
public class ClassEnumerator
{
	// Token: 0x060005C6 RID: 1478 RVA: 0x00024C54 File Offset: 0x00023054
	public ClassEnumerator(Type InAttributeType, Type InInterfaceType, Assembly InAssembly, bool bIgnoreAbstract = true, bool bInheritAttribute = false, bool bShouldCrossAssembly = false)
	{
		this.AttributeType = InAttributeType;
		this.InterfaceType = InInterfaceType;
		try
		{
			if (bShouldCrossAssembly)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				if (assemblies != null)
				{
					foreach (Assembly inAssembly in assemblies)
					{
						this.CheckInAssembly(inAssembly, bIgnoreAbstract, bInheritAttribute);
					}
				}
			}
			else
			{
				this.CheckInAssembly(InAssembly, bIgnoreAbstract, bInheritAttribute);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error in enumerate classes :" + ex.Message);
		}
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00024CFC File Offset: 0x000230FC
	protected void CheckInAssembly(Assembly InAssembly, bool bInIgnoreAbstract, bool bInInheritAttribute)
	{
		Type[] types = InAssembly.GetTypes();
		if (types != null)
		{
			foreach (Type type in types)
			{
				if ((this.InterfaceType == null || this.InterfaceType.IsAssignableFrom(type)) && (!bInIgnoreAbstract || (bInIgnoreAbstract && !type.IsAbstract)) && type.GetCustomAttributes(this.AttributeType, bInInheritAttribute).Length > 0)
				{
					this.Results.Add(type);
				}
			}
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00024D82 File Offset: 0x00023182
	public ListView<Type> results
	{
		get
		{
			return this.Results;
		}
	}

	// Token: 0x040004F5 RID: 1269
	private Type AttributeType;

	// Token: 0x040004F6 RID: 1270
	private Type InterfaceType;

	// Token: 0x040004F7 RID: 1271
	protected ListView<Type> Results = new ListView<Type>();
}
