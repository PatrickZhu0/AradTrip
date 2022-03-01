using System;

namespace behaviac
{
	// Token: 0x020033A2 RID: 13218
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node5 : Condition
	{
		// Token: 0x06014F9F RID: 85919 RVA: 0x00651D0F File Offset: 0x0065010F
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node5()
		{
			this.opl_p0 = 40000;
			this.opl_p1 = 40000;
			this.opl_p2 = 40000;
			this.opl_p3 = 40000;
		}

		// Token: 0x06014FA0 RID: 85920 RVA: 0x00651D44 File Offset: 0x00650144
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E87B RID: 59515
		private int opl_p0;

		// Token: 0x0400E87C RID: 59516
		private int opl_p1;

		// Token: 0x0400E87D RID: 59517
		private int opl_p2;

		// Token: 0x0400E87E RID: 59518
		private int opl_p3;
	}
}
