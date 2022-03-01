using System;

namespace behaviac
{
	// Token: 0x02002B00 RID: 11008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node24 : Condition
	{
		// Token: 0x06013F14 RID: 81684 RVA: 0x005FC4B7 File Offset: 0x005FA8B7
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node24()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 0;
		}

		// Token: 0x06013F15 RID: 81685 RVA: 0x005FC4D0 File Offset: 0x005FA8D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D960 RID: 55648
		private LevelCounterType opl_p0;

		// Token: 0x0400D961 RID: 55649
		private int opl_p1;
	}
}
