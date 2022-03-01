using System;

namespace behaviac
{
	// Token: 0x02003D09 RID: 15625
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node4 : Condition
	{
		// Token: 0x060161B0 RID: 90544 RVA: 0x006AEB63 File Offset: 0x006ACF63
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Baixiaoyurenheti_action_hard_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060161B1 RID: 90545 RVA: 0x006AEB98 File Offset: 0x006ACF98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA40 RID: 64064
		private int opl_p0;

		// Token: 0x0400FA41 RID: 64065
		private int opl_p1;

		// Token: 0x0400FA42 RID: 64066
		private int opl_p2;

		// Token: 0x0400FA43 RID: 64067
		private int opl_p3;
	}
}
