using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001867 RID: 6247
	public class SpringFestivalDungeonActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4E9 RID: 62697 RVA: 0x00421485 File Offset: 0x0041F885
		public sealed override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F4EA RID: 62698 RVA: 0x0042149A File Offset: 0x0041F89A
		public sealed override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F4EB RID: 62699 RVA: 0x004214AC File Offset: 0x0041F8AC
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/SpringFestivalDungeonActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}
	}
}
