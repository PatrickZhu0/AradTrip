using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200474E RID: 18254
	[ExecuteInEditMode]
	public class StatusBinder : MonoBehaviour
	{
		// Token: 0x0601A38E RID: 107406 RVA: 0x008253A7 File Offset: 0x008237A7
		private void Start()
		{
		}

		// Token: 0x0601A38F RID: 107407 RVA: 0x008253AC File Offset: 0x008237AC
		public void ChangeStatus(int iStatus)
		{
			this.iDefaultStatus = iStatus;
			StatusGroup statusGroup = this.m_akGroups.Find((StatusGroup x) => x.iTag == iStatus);
			if (statusGroup != null)
			{
				statusGroup.DoStatus();
			}
		}

		// Token: 0x0601A390 RID: 107408 RVA: 0x008253F6 File Offset: 0x008237F6
		private void OnDestroy()
		{
		}

		// Token: 0x0601A391 RID: 107409 RVA: 0x008253F8 File Offset: 0x008237F8
		private void _Update()
		{
			if (this.iPreData != this.iDefaultStatus)
			{
				this.iPreData = this.iDefaultStatus;
				this.ChangeStatus(this.iPreData);
			}
		}

		// Token: 0x040126BB RID: 75451
		public int iDefaultStatus;

		// Token: 0x040126BC RID: 75452
		public List<StatusGroup> m_akGroups = new List<StatusGroup>();

		// Token: 0x040126BD RID: 75453
		private int iPreData = -1;
	}
}
