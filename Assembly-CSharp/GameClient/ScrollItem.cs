using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F10 RID: 3856
	public abstract class ScrollItem
	{
		// Token: 0x06009689 RID: 38537 RVA: 0x001C9B89 File Offset: 0x001C7F89
		public int GetDataID()
		{
			return this.m_nDataID;
		}

		// Token: 0x0600968A RID: 38538 RVA: 0x001C9B91 File Offset: 0x001C7F91
		public void Setup(int a_nDataID)
		{
			this.m_nDataID = a_nDataID;
			this._Refresh(a_nDataID);
		}

		// Token: 0x0600968B RID: 38539
		public abstract ScrollItem Clone();

		// Token: 0x0600968C RID: 38540
		public abstract void Destroy();

		// Token: 0x0600968D RID: 38541
		public abstract void SetAsFirstSibling();

		// Token: 0x0600968E RID: 38542
		public abstract void SetAsLastSibling();

		// Token: 0x0600968F RID: 38543
		public abstract void SetActive(bool a_bActive);

		// Token: 0x06009690 RID: 38544
		public abstract bool IsActive();

		// Token: 0x06009691 RID: 38545
		public abstract Vector3 GetPosInContent();

		// Token: 0x06009692 RID: 38546
		protected abstract void _Refresh(int a_nDataID);

		// Token: 0x04004D5F RID: 19807
		private int m_nDataID;
	}
}
