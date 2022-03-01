using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200186A RID: 6250
	public class SummerVacationWeeklyActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4F6 RID: 62710 RVA: 0x0042153B File Offset: 0x0041F93B
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4F7 RID: 62711 RVA: 0x00421544 File Offset: 0x0041F944
		public override void Show(Transform root)
		{
			base.Show(root);
		}

		// Token: 0x0600F4F8 RID: 62712 RVA: 0x0042154D File Offset: 0x0041F94D
		public override void UpdateData()
		{
			base.UpdateData();
		}

		// Token: 0x0600F4F9 RID: 62713 RVA: 0x00421555 File Offset: 0x0041F955
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4FA RID: 62714 RVA: 0x0042155D File Offset: 0x0041F95D
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/SummerVacationWeeklyItem";
		}

		// Token: 0x0600F4FB RID: 62715 RVA: 0x00421564 File Offset: 0x0041F964
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/SummerVacationWeeklyActivity";
		}
	}
}
