using System;

namespace behaviac
{
	// Token: 0x02002B24 RID: 11044
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node27 : Condition
	{
		// Token: 0x06013F5A RID: 81754 RVA: 0x005FD9C2 File Offset: 0x005FBDC2
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node27()
		{
			this.opl_p0 = LevelCounterType.WindDir;
			this.opl_p1 = 1;
		}

		// Token: 0x06013F5B RID: 81755 RVA: 0x005FD9D8 File Offset: 0x005FBDD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_CheckCounter(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D996 RID: 55702
		private LevelCounterType opl_p0;

		// Token: 0x0400D997 RID: 55703
		private int opl_p1;
	}
}
