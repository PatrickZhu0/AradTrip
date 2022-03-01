using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200181D RID: 6173
	public class CourtesyPrivilegesActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F328 RID: 62248 RVA: 0x0041B6A0 File Offset: 0x00419AA0
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F329 RID: 62249 RVA: 0x0041B6B5 File Offset: 0x00419AB5
		public override bool IsHaveRedPoint()
		{
			return !DataManager<ActivityManager>.GetInstance().CheckCourtesyPrivilegesActivityIsExpire() && !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F32A RID: 62250 RVA: 0x0041B6D6 File Offset: 0x00419AD6
		protected override string _GetPrefabPath()
		{
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return "UIFlatten/Prefabs/OperateActivity/CourtesyPrivilegeActivity/CourtesyPrivilegesActivity";
		}
	}
}
