using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProtoTable
{
	// Token: 0x02000259 RID: 601
	[Serializable]
	public class TableData : ScriptableObject
	{
		// Token: 0x0600137D RID: 4989 RVA: 0x00068A72 File Offset: 0x00066E72
		public virtual void Init()
		{
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00068A74 File Offset: 0x00066E74
		public virtual void InitItems()
		{
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00068A76 File Offset: 0x00066E76
		public virtual void BuildData(object[] data)
		{
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00068A78 File Offset: 0x00066E78
		public virtual IEnumerable<object> GetData()
		{
			yield break;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x00068A94 File Offset: 0x00066E94
		public virtual object[] GetAll()
		{
			return null;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00068A97 File Offset: 0x00066E97
		public virtual Dictionary<int, object> GetMap()
		{
			return null;
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00068A9A File Offset: 0x00066E9A
		public virtual bool IsEmpty()
		{
			return true;
		}
	}
}
