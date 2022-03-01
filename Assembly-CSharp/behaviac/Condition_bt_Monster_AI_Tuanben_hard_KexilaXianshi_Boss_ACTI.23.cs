using System;

namespace behaviac
{
	// Token: 0x02003C85 RID: 15493
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node39 : Condition
	{
		// Token: 0x060160B1 RID: 90289 RVA: 0x006A93E3 File Offset: 0x006A77E3
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node39()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 6000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060160B2 RID: 90290 RVA: 0x006A9418 File Offset: 0x006A7818
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F946 RID: 63814
		private int opl_p0;

		// Token: 0x0400F947 RID: 63815
		private int opl_p1;

		// Token: 0x0400F948 RID: 63816
		private int opl_p2;

		// Token: 0x0400F949 RID: 63817
		private int opl_p3;
	}
}
