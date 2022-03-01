using System;
using System.Collections.Generic;

// Token: 0x020006B3 RID: 1715
internal class ProtocolHelper : Singleton<ProtocolHelper>
{
	// Token: 0x0600584F RID: 22607 RVA: 0x0010CB0F File Offset: 0x0010AF0F
	public static string ID2Name(uint id)
	{
		return Singleton<ProtocolHelper>.instance.GetName(id);
	}

	// Token: 0x06005850 RID: 22608 RVA: 0x0010CB1C File Offset: 0x0010AF1C
	public string GetName(uint id)
	{
		string result;
		if (this.m_id2name.TryGetValue(id, out result))
		{
			return result;
		}
		return "unknown(" + id.ToString() + ")";
	}

	// Token: 0x06005851 RID: 22609 RVA: 0x0010CB5A File Offset: 0x0010AF5A
	public override void Init()
	{
	}

	// Token: 0x06005852 RID: 22610 RVA: 0x0010CB5C File Offset: 0x0010AF5C
	private void Register(uint id, string name)
	{
		if (this.m_id2name.ContainsKey(id))
		{
			Logger.LogErrorFormat("duplicate protocol id:" + id, new object[0]);
			return;
		}
		this.m_id2name.Add(id, name);
	}

	// Token: 0x04002324 RID: 8996
	private Dictionary<uint, string> m_id2name = new Dictionary<uint, string>();
}
