using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200474B RID: 18251
	[Serializable]
	public class PositionStatus : IStatus
	{
		// Token: 0x0601A387 RID: 107399 RVA: 0x0082529D File Offset: 0x0082369D
		public PositionStatus()
		{
			this.m_eIStatusFuntion = IStatus.IStatusFuntion.ISF_POSITION;
		}

		// Token: 0x0601A388 RID: 107400 RVA: 0x008252AC File Offset: 0x008236AC
		public override void DoStatus()
		{
			if (this.target != null)
			{
				this.target.transform.localPosition = this.position;
			}
		}

		// Token: 0x040126B4 RID: 75444
		public Vector3 position;

		// Token: 0x040126B5 RID: 75445
		public GameObject target;
	}
}
