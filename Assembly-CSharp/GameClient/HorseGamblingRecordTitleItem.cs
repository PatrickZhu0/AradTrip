using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200168F RID: 5775
	public class HorseGamblingRecordTitleItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600E2F0 RID: 58096 RVA: 0x003A50A7 File Offset: 0x003A34A7
		public void Init(string name)
		{
			base.gameObject.CustomActive(true);
			this.mTextName.SafeSetText(name);
		}

		// Token: 0x0600E2F1 RID: 58097 RVA: 0x003A50C1 File Offset: 0x003A34C1
		public void Dispose()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x040087CF RID: 34767
		[SerializeField]
		private Text mTextName;
	}
}
