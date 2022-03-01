using System;
using System.Collections.Generic;

// Token: 0x020001F0 RID: 496
public class TypeTable : Singleton<TypeTable>
{
	// Token: 0x06000FF4 RID: 4084 RVA: 0x00053D52 File Offset: 0x00052152
	public static Type GetType(string typeName)
	{
		return Singleton<TypeTable>.instance._GetType(typeName);
	}

	// Token: 0x06000FF5 RID: 4085 RVA: 0x00053D60 File Offset: 0x00052160
	public Type _GetType(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		Type type = null;
		if (this.m_TypeTable.TryGetValue(typeName, out type))
		{
			return type;
		}
		type = Type.GetType(typeName);
		this.m_TypeTable.Add(typeName, type);
		return type;
	}

	// Token: 0x06000FF6 RID: 4086 RVA: 0x00053DA6 File Offset: 0x000521A6
	public void ClearAll()
	{
		this.m_TypeTable.Clear();
	}

	// Token: 0x04000AEB RID: 2795
	private Dictionary<string, Type> m_TypeTable = new Dictionary<string, Type>();
}
