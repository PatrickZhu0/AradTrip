using System;

namespace behaviac
{
	// Token: 0x020034E3 RID: 13539
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node25 : Condition
	{
		// Token: 0x0601520B RID: 86539 RVA: 0x0065DCDB File Offset: 0x0065C0DB
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node25()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601520C RID: 86540 RVA: 0x0065DD10 File Offset: 0x0065C110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB24 RID: 60196
		private int opl_p0;

		// Token: 0x0400EB25 RID: 60197
		private int opl_p1;

		// Token: 0x0400EB26 RID: 60198
		private int opl_p2;

		// Token: 0x0400EB27 RID: 60199
		private int opl_p3;
	}
}
