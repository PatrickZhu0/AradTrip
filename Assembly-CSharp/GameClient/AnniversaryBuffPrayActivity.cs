using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200180B RID: 6155
	public class AnniversaryBuffPrayActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F297 RID: 62103 RVA: 0x00417209 File Offset: 0x00415609
		protected sealed override string _GetPrefabPath()
		{
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryBuffPrayActivity";
		}

		// Token: 0x0600F298 RID: 62104 RVA: 0x0041723C File Offset: 0x0041563C
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Item/AnniversaryBuffPrayItem";
		}

		// Token: 0x0600F299 RID: 62105 RVA: 0x00417243 File Offset: 0x00415643
		public sealed override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F29A RID: 62106 RVA: 0x00417258 File Offset: 0x00415658
		public sealed override void UpdateData()
		{
			base.UpdateData();
		}

		// Token: 0x0600F29B RID: 62107 RVA: 0x00417260 File Offset: 0x00415660
		public sealed override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}
	}
}
