using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200182A RID: 6186
	public class BuffPrayActivityNew : LimitTimeCommonActivity
	{
		// Token: 0x0600F38D RID: 62349 RVA: 0x0041D020 File Offset: 0x0041B420
		protected sealed override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/BuffPrayActivityNew";
		}

		// Token: 0x0600F38E RID: 62350 RVA: 0x0041D027 File Offset: 0x0041B427
		public sealed override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F38F RID: 62351 RVA: 0x0041D03C File Offset: 0x0041B43C
		public sealed override void UpdateData()
		{
			base.UpdateData();
		}

		// Token: 0x0600F390 RID: 62352 RVA: 0x0041D044 File Offset: 0x0041B444
		public sealed override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}
	}
}
