using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A92 RID: 6802
	public class WeekSignInAwardRecordItem : MonoBehaviour
	{
		// Token: 0x06010B22 RID: 68386 RVA: 0x004BC251 File Offset: 0x004BA651
		private void OnDestroy()
		{
			this._contentStr = null;
		}

		// Token: 0x06010B23 RID: 68387 RVA: 0x004BC25A File Offset: 0x004BA65A
		public void InitItem(string contentStr)
		{
			this._contentStr = contentStr;
			if (this.linkParseControl != null)
			{
				this.linkParseControl.SetText(contentStr, true);
			}
		}

		// Token: 0x0400AAC2 RID: 43714
		private string _contentStr;

		// Token: 0x0400AAC3 RID: 43715
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private LinkParse linkParseControl;
	}
}
