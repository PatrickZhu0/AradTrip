using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200141E RID: 5150
	public class AdventureTeamExpedtionResultRoleInfo : MonoBehaviour
	{
		// Token: 0x0600C797 RID: 51095 RVA: 0x00304831 File Offset: 0x00302C31
		private void _SetRoleIcon(string imgPath)
		{
			this.roleIcon.SafeSetImage(imgPath, false);
		}

		// Token: 0x0600C798 RID: 51096 RVA: 0x00304840 File Offset: 0x00302C40
		public void RefreshView(int jobId)
		{
			string roleIconByRoleId = Utility.GetRoleIconByRoleId(jobId);
			this._SetRoleIcon(roleIconByRoleId);
		}

		// Token: 0x040072A4 RID: 29348
		[SerializeField]
		private Image roleIcon;
	}
}
