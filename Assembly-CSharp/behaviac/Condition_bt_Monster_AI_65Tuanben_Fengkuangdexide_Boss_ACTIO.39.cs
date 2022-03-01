using System;

namespace behaviac
{
	// Token: 0x02002EE3 RID: 12003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node26 : Condition
	{
		// Token: 0x060146A0 RID: 83616 RVA: 0x00623157 File Offset: 0x00621557
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node26()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1800;
			this.opl_p2 = 1800;
			this.opl_p3 = 1500;
		}

		// Token: 0x060146A1 RID: 83617 RVA: 0x0062318C File Offset: 0x0062158C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E017 RID: 57367
		private int opl_p0;

		// Token: 0x0400E018 RID: 57368
		private int opl_p1;

		// Token: 0x0400E019 RID: 57369
		private int opl_p2;

		// Token: 0x0400E01A RID: 57370
		private int opl_p3;
	}
}
