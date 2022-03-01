using System;

namespace behaviac
{
	// Token: 0x02002ECE RID: 11982
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node47 : Condition
	{
		// Token: 0x06014676 RID: 83574 RVA: 0x00622868 File Offset: 0x00620C68
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node47()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570297;
		}

		// Token: 0x06014677 RID: 83575 RVA: 0x0062288C File Offset: 0x00620C8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFE3 RID: 57315
		private BE_Target opl_p0;

		// Token: 0x0400DFE4 RID: 57316
		private BE_Equal opl_p1;

		// Token: 0x0400DFE5 RID: 57317
		private int opl_p2;
	}
}
