using System;

namespace behaviac
{
	// Token: 0x02002B06 RID: 11014
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_node27 : Condition
	{
		// Token: 0x06013F20 RID: 81696 RVA: 0x005FC71A File Offset: 0x005FAB1A
		public Condition_bt_Level_Tuanben_TuanBen_Wind_node27()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 1;
		}

		// Token: 0x06013F21 RID: 81697 RVA: 0x005FC730 File Offset: 0x005FAB30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D96C RID: 55660
		private LevelCounterType opl_p0;

		// Token: 0x0400D96D RID: 55661
		private int opl_p1;
	}
}
