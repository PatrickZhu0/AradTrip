using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200180C RID: 6156
	public class AnniversaryPartyActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F29D RID: 62109 RVA: 0x00417278 File Offset: 0x00415678
		protected sealed override string _GetPrefabPath()
		{
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryPartyActivity";
		}

		// Token: 0x0600F29E RID: 62110 RVA: 0x004172AB File Offset: 0x004156AB
		protected override string _GetItemPrefabPath()
		{
			return string.Empty;
		}

		// Token: 0x0600F29F RID: 62111 RVA: 0x004172B2 File Offset: 0x004156B2
		public sealed override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F2A0 RID: 62112 RVA: 0x004172C7 File Offset: 0x004156C7
		public sealed override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}
	}
}
