using System;

namespace behaviac
{
	// Token: 0x02002B03 RID: 11011
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node25 : Condition
	{
		// Token: 0x06013F1A RID: 81690 RVA: 0x005FC5EA File Offset: 0x005FA9EA
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node25()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 0;
		}

		// Token: 0x06013F1B RID: 81691 RVA: 0x005FC600 File Offset: 0x005FAA00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D966 RID: 55654
		private LevelCounterType opl_p0;

		// Token: 0x0400D967 RID: 55655
		private int opl_p1;
	}
}
