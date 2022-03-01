using System;

namespace behaviac
{
	// Token: 0x02003D2D RID: 15661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node4 : Condition
	{
		// Token: 0x060161F4 RID: 90612 RVA: 0x006AFF7B File Offset: 0x006AE37B
		public Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_action_hard_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060161F5 RID: 90613 RVA: 0x006AFFB0 File Offset: 0x006AE3B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA6A RID: 64106
		private int opl_p0;

		// Token: 0x0400FA6B RID: 64107
		private int opl_p1;

		// Token: 0x0400FA6C RID: 64108
		private int opl_p2;

		// Token: 0x0400FA6D RID: 64109
		private int opl_p3;
	}
}
