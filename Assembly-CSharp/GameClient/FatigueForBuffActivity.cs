using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200183F RID: 6207
	public sealed class FatigueForBuffActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3E6 RID: 62438 RVA: 0x0041E1B7 File Offset: 0x0041C5B7
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			if (this.mDataModel != null)
			{
				this.mDataModel.SortTaskByState();
			}
		}

		// Token: 0x0600F3E7 RID: 62439 RVA: 0x0041E1D6 File Offset: 0x0041C5D6
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F3E8 RID: 62440 RVA: 0x0041E1EB File Offset: 0x0041C5EB
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F3E9 RID: 62441 RVA: 0x0041E1FB File Offset: 0x0041C5FB
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/FatigueForBuffItem";
		}
	}
}
