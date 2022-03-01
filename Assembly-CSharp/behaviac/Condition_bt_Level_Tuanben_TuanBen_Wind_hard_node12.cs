using System;

namespace behaviac
{
	// Token: 0x02002B19 RID: 11033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node12 : Condition
	{
		// Token: 0x06013F44 RID: 81732 RVA: 0x005FD61A File Offset: 0x005FBA1A
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node12()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013F45 RID: 81733 RVA: 0x005FD630 File Offset: 0x005FBA30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D985 RID: 55685
		private int opl_p0;
	}
}
