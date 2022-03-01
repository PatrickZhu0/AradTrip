using System;

namespace behaviac
{
	// Token: 0x02003CAC RID: 15532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node59 : Condition
	{
		// Token: 0x060160FF RID: 90367 RVA: 0x006AA562 File Offset: 0x006A8962
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node59()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016100 RID: 90368 RVA: 0x006AA598 File Offset: 0x006A8998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9A5 RID: 63909
		private int opl_p0;

		// Token: 0x0400F9A6 RID: 63910
		private int opl_p1;

		// Token: 0x0400F9A7 RID: 63911
		private int opl_p2;

		// Token: 0x0400F9A8 RID: 63912
		private int opl_p3;
	}
}
