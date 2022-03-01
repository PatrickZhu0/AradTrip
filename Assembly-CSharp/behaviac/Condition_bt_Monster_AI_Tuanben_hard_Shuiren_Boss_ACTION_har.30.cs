using System;

namespace behaviac
{
	// Token: 0x02003D69 RID: 15721
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node50 : Condition
	{
		// Token: 0x06016268 RID: 90728 RVA: 0x006B1653 File Offset: 0x006AFA53
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node50()
		{
			this.opl_p0 = 50000;
			this.opl_p1 = 50000;
			this.opl_p2 = 50000;
			this.opl_p3 = 50000;
		}

		// Token: 0x06016269 RID: 90729 RVA: 0x006B1688 File Offset: 0x006AFA88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC1 RID: 64193
		private int opl_p0;

		// Token: 0x0400FAC2 RID: 64194
		private int opl_p1;

		// Token: 0x0400FAC3 RID: 64195
		private int opl_p2;

		// Token: 0x0400FAC4 RID: 64196
		private int opl_p3;
	}
}
