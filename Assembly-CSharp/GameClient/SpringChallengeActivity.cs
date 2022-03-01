using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001866 RID: 6246
	public class SpringChallengeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4E4 RID: 62692 RVA: 0x0042140F File Offset: 0x0041F80F
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F4E5 RID: 62693 RVA: 0x0042141F File Offset: 0x0041F81F
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F4E6 RID: 62694 RVA: 0x00421434 File Offset: 0x0041F834
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/SpringChallengeActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}

		// Token: 0x0600F4E7 RID: 62695 RVA: 0x00421476 File Offset: 0x0041F876
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/SpringChallengeItem";
		}
	}
}
