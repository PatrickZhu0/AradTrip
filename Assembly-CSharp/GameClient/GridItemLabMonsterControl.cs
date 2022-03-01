using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C67 RID: 7271
	public class GridItemLabMonsterControl : MonoBehaviour
	{
		// Token: 0x06011DD9 RID: 73177 RVA: 0x0053AD16 File Offset: 0x00539116
		public void UpdateLabMonsterControl(uint cdTime, uint endTimeStamp)
		{
			if (this.gridItemProfessBarControl != null)
			{
				this.gridItemProfessBarControl.UpdateProgressBarControl(cdTime, endTimeStamp, null);
			}
		}

		// Token: 0x0400BA23 RID: 47651
		[SerializeField]
		private GridItemProgressBarControl gridItemProfessBarControl;
	}
}
