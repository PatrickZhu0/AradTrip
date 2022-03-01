using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D3C RID: 3388
	[Serializable]
	public class GeUIEffectDataBlock
	{
		// Token: 0x06008A10 RID: 35344 RVA: 0x0019405B File Offset: 0x0019245B
		public GeUIEffectDataBlock(string name, string value)
		{
			this.m_Name = name;
			this.m_Value = value;
		}

		// Token: 0x040043F8 RID: 17400
		public string m_Name;

		// Token: 0x040043F9 RID: 17401
		public string m_Value;
	}
}
