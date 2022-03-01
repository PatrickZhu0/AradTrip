using System;

namespace behaviac
{
	// Token: 0x02002EE7 RID: 12007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node80 : Condition
	{
		// Token: 0x060146A8 RID: 83624 RVA: 0x00623323 File Offset: 0x00621723
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node80()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060146A9 RID: 83625 RVA: 0x00623358 File Offset: 0x00621758
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E021 RID: 57377
		private int opl_p0;

		// Token: 0x0400E022 RID: 57378
		private int opl_p1;

		// Token: 0x0400E023 RID: 57379
		private int opl_p2;

		// Token: 0x0400E024 RID: 57380
		private int opl_p3;
	}
}
