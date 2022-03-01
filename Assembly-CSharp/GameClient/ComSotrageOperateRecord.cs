using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000057 RID: 87
	internal class ComSotrageOperateRecord : MonoBehaviour
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x00010925 File Offset: 0x0000ED25
		public void OnCreate()
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00010928 File Offset: 0x0000ED28
		public void OnItemVisible(object data)
		{
			this.recordsData = (data as SotrageOperateRecordData);
			if (null != this.linkParse)
			{
				if (this.recordsData == null)
				{
					this.linkParse.SetText(string.Empty, false);
				}
				else
				{
					this.linkParse.SetText(this.recordsData.value, true);
				}
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0001098A File Offset: 0x0000ED8A
		private void OnDestroy()
		{
			this.recordsData = null;
			this.linkParse = null;
		}

		// Token: 0x040001F4 RID: 500
		public LinkParse linkParse;

		// Token: 0x040001F5 RID: 501
		private SotrageOperateRecordData recordsData;
	}
}
