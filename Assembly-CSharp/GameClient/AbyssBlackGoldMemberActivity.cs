using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001821 RID: 6177
	public class AbyssBlackGoldMemberActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F34B RID: 62283 RVA: 0x0041C59A File Offset: 0x0041A99A
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F34C RID: 62284 RVA: 0x0041C5AF File Offset: 0x0041A9AF
		public override bool IsHaveRedPoint()
		{
			return !DataManager<ActivityManager>.GetInstance().CheckAbyssBlackGoldMemberActivityIsExpire() && !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F34D RID: 62285 RVA: 0x0041C5D0 File Offset: 0x0041A9D0
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/AbyssBlackGoldMemberActivity";
		}
	}
}
