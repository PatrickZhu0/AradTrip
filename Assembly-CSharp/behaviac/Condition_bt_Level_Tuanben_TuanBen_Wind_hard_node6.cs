using System;

namespace behaviac
{
	// Token: 0x02002B15 RID: 11029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node6 : Condition
	{
		// Token: 0x06013F3C RID: 81724 RVA: 0x005FD510 File Offset: 0x005FB910
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node6()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = -1;
		}

		// Token: 0x06013F3D RID: 81725 RVA: 0x005FD528 File Offset: 0x005FB928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D97E RID: 55678
		private LevelCounterType opl_p0;

		// Token: 0x0400D97F RID: 55679
		private int opl_p1;
	}
}
