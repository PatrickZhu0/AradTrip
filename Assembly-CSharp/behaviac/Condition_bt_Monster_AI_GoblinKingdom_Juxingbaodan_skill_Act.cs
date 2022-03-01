using System;

namespace behaviac
{
	// Token: 0x02003396 RID: 13206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node9 : Condition
	{
		// Token: 0x06014F87 RID: 85895 RVA: 0x0065186D File Offset: 0x0064FC6D
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node9()
		{
			this.opl_p0 = 40000;
			this.opl_p1 = 40000;
			this.opl_p2 = 40000;
			this.opl_p3 = 40000;
		}

		// Token: 0x06014F88 RID: 85896 RVA: 0x006518A4 File Offset: 0x0064FCA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E863 RID: 59491
		private int opl_p0;

		// Token: 0x0400E864 RID: 59492
		private int opl_p1;

		// Token: 0x0400E865 RID: 59493
		private int opl_p2;

		// Token: 0x0400E866 RID: 59494
		private int opl_p3;
	}
}
