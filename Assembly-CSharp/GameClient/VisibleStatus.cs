using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200474C RID: 18252
	[Serializable]
	public class VisibleStatus : IStatus
	{
		// Token: 0x0601A389 RID: 107401 RVA: 0x008252D5 File Offset: 0x008236D5
		public VisibleStatus()
		{
			this.m_eIStatusFuntion = IStatus.IStatusFuntion.ISF_VISIBLE;
		}

		// Token: 0x0601A38A RID: 107402 RVA: 0x008252E4 File Offset: 0x008236E4
		public override void DoStatus()
		{
			if (this.target != null)
			{
				this.target.CustomActive(this.bVisible);
			}
		}

		// Token: 0x040126B6 RID: 75446
		public bool bVisible;

		// Token: 0x040126B7 RID: 75447
		public GameObject target;
	}
}
