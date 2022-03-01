using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020001F3 RID: 499
	[Serializable]
	public class ScriptStateItem : IComparable
	{
		// Token: 0x06000FFF RID: 4095 RVA: 0x00053F18 File Offset: 0x00052318
		public int CompareTo(object obj)
		{
			if (obj is ScriptStateItem)
			{
				return this.bindIndex - (obj as ScriptStateItem).bindIndex;
			}
			if (obj is int)
			{
				return this.bindIndex - (int)obj;
			}
			throw new ArgumentException("object can not compare with ScriptStateItem !!!");
		}

		// Token: 0x04000AF6 RID: 2806
		public int bindIndex;

		// Token: 0x04000AF7 RID: 2807
		public UnityEvent action;
	}
}
