using System;

namespace behaviac
{
	// Token: 0x02002AF7 RID: 10999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node6 : Condition
	{
		// Token: 0x06013F02 RID: 81666 RVA: 0x005FC268 File Offset: 0x005FA668
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node6()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = -1;
		}

		// Token: 0x06013F03 RID: 81667 RVA: 0x005FC280 File Offset: 0x005FA680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D954 RID: 55636
		private LevelCounterType opl_p0;

		// Token: 0x0400D955 RID: 55637
		private int opl_p1;
	}
}
