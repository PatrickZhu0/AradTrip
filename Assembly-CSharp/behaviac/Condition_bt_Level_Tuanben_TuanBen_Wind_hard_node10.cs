using System;

namespace behaviac
{
	// Token: 0x02002B17 RID: 11031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node10 : Condition
	{
		// Token: 0x06013F40 RID: 81728 RVA: 0x005FD59B File Offset: 0x005FB99B
		public Condition_bt_Level_Tuanben_TuanBen_Wind_hard_node10()
		{
			this.opl_p0 = 450;
		}

		// Token: 0x06013F41 RID: 81729 RVA: 0x005FD5B0 File Offset: 0x005FB9B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((LevelAgent)pAgent).Condition_Random(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D982 RID: 55682
		private int opl_p0;
	}
}
