using System;

namespace GameClient
{
	// Token: 0x02001860 RID: 6240
	public sealed class ReservationUpgradeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4B9 RID: 62649 RVA: 0x00420C35 File Offset: 0x0041F035
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			if (this.mDataModel != null)
			{
				this.mDataModel.SortTaskByState();
			}
		}

		// Token: 0x0600F4BA RID: 62650 RVA: 0x00420C54 File Offset: 0x0041F054
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ReservationUpgradeActivity";
		}

		// Token: 0x0600F4BB RID: 62651 RVA: 0x00420C5B File Offset: 0x0041F05B
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ReservationUpgradeItem";
		}
	}
}
