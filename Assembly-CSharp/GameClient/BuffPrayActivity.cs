using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001829 RID: 6185
	public class BuffPrayActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F388 RID: 62344 RVA: 0x0041CFE4 File Offset: 0x0041B3E4
		protected sealed override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/BuffPrayActivity";
		}

		// Token: 0x0600F389 RID: 62345 RVA: 0x0041CFEB File Offset: 0x0041B3EB
		public sealed override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F38A RID: 62346 RVA: 0x0041D000 File Offset: 0x0041B400
		public sealed override void UpdateData()
		{
			base.UpdateData();
		}

		// Token: 0x0600F38B RID: 62347 RVA: 0x0041D008 File Offset: 0x0041B408
		public sealed override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}
	}
}
