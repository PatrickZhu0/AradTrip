using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020001F2 RID: 498
	[Serializable]
	public class ScriptBinderItem : IComparable
	{
		// Token: 0x06000FFD RID: 4093 RVA: 0x00053EC0 File Offset: 0x000522C0
		public int CompareTo(object obj)
		{
			if (obj is ScriptBinderItem)
			{
				return this.bindIndex - (obj as ScriptBinderItem).bindIndex;
			}
			if (obj is int)
			{
				return this.bindIndex - (int)obj;
			}
			throw new ArgumentException("object can not compare with ScriptBinderItem !!!");
		}

		// Token: 0x04000AF2 RID: 2802
		public int bindIndex;

		// Token: 0x04000AF3 RID: 2803
		public Object component;

		// Token: 0x04000AF4 RID: 2804
		public string varName;

		// Token: 0x04000AF5 RID: 2805
		public bool locked;
	}
}
