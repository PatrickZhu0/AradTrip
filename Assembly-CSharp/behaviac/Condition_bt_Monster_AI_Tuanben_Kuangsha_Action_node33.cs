using System;

namespace behaviac
{
	// Token: 0x02003AC2 RID: 15042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node33 : Condition
	{
		// Token: 0x06015D43 RID: 89411 RVA: 0x006985EA File Offset: 0x006969EA
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node33()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D44 RID: 89412 RVA: 0x00698620 File Offset: 0x00696A20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F654 RID: 63060
		private int opl_p0;

		// Token: 0x0400F655 RID: 63061
		private int opl_p1;

		// Token: 0x0400F656 RID: 63062
		private int opl_p2;

		// Token: 0x0400F657 RID: 63063
		private int opl_p3;
	}
}
