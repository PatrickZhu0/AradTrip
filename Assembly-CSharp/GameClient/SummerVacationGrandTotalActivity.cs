using System;

namespace GameClient
{
	// Token: 0x02001869 RID: 6249
	public class SummerVacationGrandTotalActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4F0 RID: 62704 RVA: 0x0042150C File Offset: 0x0041F90C
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4F1 RID: 62705 RVA: 0x00421515 File Offset: 0x0041F915
		public override void UpdateData()
		{
			base.UpdateData();
		}

		// Token: 0x0600F4F2 RID: 62706 RVA: 0x0042151D File Offset: 0x0041F91D
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4F3 RID: 62707 RVA: 0x00421525 File Offset: 0x0041F925
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/SummerVacationGrandTotalItem";
		}

		// Token: 0x0600F4F4 RID: 62708 RVA: 0x0042152C File Offset: 0x0041F92C
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/SummerVacationGrandTotalActivity";
		}
	}
}
