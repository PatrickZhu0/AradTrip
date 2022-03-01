using System;

namespace behaviac
{
	// Token: 0x02002E56 RID: 11862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node195 : Condition
	{
		// Token: 0x06014589 RID: 83337 RVA: 0x0061B72A File Offset: 0x00619B2A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node195()
		{
			this.opl_p0 = 1200;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601458A RID: 83338 RVA: 0x0061B760 File Offset: 0x00619B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF1C RID: 57116
		private int opl_p0;

		// Token: 0x0400DF1D RID: 57117
		private int opl_p1;

		// Token: 0x0400DF1E RID: 57118
		private int opl_p2;

		// Token: 0x0400DF1F RID: 57119
		private int opl_p3;
	}
}
