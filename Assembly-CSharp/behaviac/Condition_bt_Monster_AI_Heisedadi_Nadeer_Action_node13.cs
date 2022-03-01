using System;

namespace behaviac
{
	// Token: 0x020034DB RID: 13531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node13 : Condition
	{
		// Token: 0x060151FB RID: 86523 RVA: 0x0065D943 File Offset: 0x0065BD43
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node13()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060151FC RID: 86524 RVA: 0x0065D978 File Offset: 0x0065BD78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB10 RID: 60176
		private int opl_p0;

		// Token: 0x0400EB11 RID: 60177
		private int opl_p1;

		// Token: 0x0400EB12 RID: 60178
		private int opl_p2;

		// Token: 0x0400EB13 RID: 60179
		private int opl_p3;
	}
}
