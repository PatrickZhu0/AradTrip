using System;
using System.Collections.Generic;

// Token: 0x020001DA RID: 474
public class ObjectLeakDitector
{
	// Token: 0x06000F17 RID: 3863 RVA: 0x00024D92 File Offset: 0x00023192
	public static void DumpObjectRef()
	{
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x00024D94 File Offset: 0x00023194
	private static void AddObjectRef(Type type)
	{
		ObjectLeakDitector.ObjRefDesc objRefDesc = null;
		if (!ObjectLeakDitector.sm_ObjectRefMap.TryGetValue(type, out objRefDesc))
		{
			objRefDesc = new ObjectLeakDitector.ObjRefDesc();
			ObjectLeakDitector.sm_ObjectRefMap.Add(type, objRefDesc);
		}
		if (objRefDesc != null)
		{
			objRefDesc.m_AllocTotal++;
		}
		else
		{
			Logger.LogError("### 严重错误，添加类型记录失败！！");
		}
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x00024DEC File Offset: 0x000231EC
	private static void RemoveObjectRef(Type type)
	{
		ObjectLeakDitector.ObjRefDesc objRefDesc = null;
		if (ObjectLeakDitector.sm_ObjectRefMap.TryGetValue(type, out objRefDesc))
		{
			objRefDesc.m_DestroyTotal++;
		}
		else
		{
			Logger.LogError("### 严重错误，没有找到匹配类型的添加记录！！");
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x00024E2C File Offset: 0x0002322C
	~ObjectLeakDitector()
	{
	}

	// Token: 0x04000A6C RID: 2668
	private static Dictionary<Type, ObjectLeakDitector.ObjRefDesc> sm_ObjectRefMap = new Dictionary<Type, ObjectLeakDitector.ObjRefDesc>();

	// Token: 0x020001DB RID: 475
	private class ObjRefDesc
	{
		// Token: 0x04000A6D RID: 2669
		public int m_AllocTotal;

		// Token: 0x04000A6E RID: 2670
		public int m_DestroyTotal;
	}
}
