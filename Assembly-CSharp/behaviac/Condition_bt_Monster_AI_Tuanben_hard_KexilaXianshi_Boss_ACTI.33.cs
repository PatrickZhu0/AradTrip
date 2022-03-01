using System;

namespace behaviac
{
	// Token: 0x02003C93 RID: 15507
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node31 : Condition
	{
		// Token: 0x060160CD RID: 90317 RVA: 0x006A9A53 File Offset: 0x006A7E53
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node31()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160CE RID: 90318 RVA: 0x006A9A88 File Offset: 0x006A7E88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F968 RID: 63848
		private int opl_p0;

		// Token: 0x0400F969 RID: 63849
		private int opl_p1;

		// Token: 0x0400F96A RID: 63850
		private int opl_p2;

		// Token: 0x0400F96B RID: 63851
		private int opl_p3;
	}
}
