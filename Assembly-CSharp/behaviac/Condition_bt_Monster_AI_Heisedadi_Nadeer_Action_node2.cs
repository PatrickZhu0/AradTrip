using System;

namespace behaviac
{
	// Token: 0x020034D0 RID: 13520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node2 : Condition
	{
		// Token: 0x060151E5 RID: 86501 RVA: 0x0065D43C File Offset: 0x0065B83C
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060151E6 RID: 86502 RVA: 0x0065D470 File Offset: 0x0065B870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAF5 RID: 60149
		private int opl_p0;

		// Token: 0x0400EAF6 RID: 60150
		private int opl_p1;

		// Token: 0x0400EAF7 RID: 60151
		private int opl_p2;

		// Token: 0x0400EAF8 RID: 60152
		private int opl_p3;
	}
}
