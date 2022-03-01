using System;

namespace behaviac
{
	// Token: 0x02003ACF RID: 15055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node51 : Condition
	{
		// Token: 0x06015D5D RID: 89437 RVA: 0x00698A2F File Offset: 0x00696E2F
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node51()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015D5E RID: 89438 RVA: 0x00698A64 File Offset: 0x00696E64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F669 RID: 63081
		private int opl_p0;

		// Token: 0x0400F66A RID: 63082
		private int opl_p1;

		// Token: 0x0400F66B RID: 63083
		private int opl_p2;

		// Token: 0x0400F66C RID: 63084
		private int opl_p3;
	}
}
