using System;

namespace behaviac
{
	// Token: 0x02002CFC RID: 11516
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node54 : Condition
	{
		// Token: 0x060142E8 RID: 82664 RVA: 0x0060F4C1 File Offset: 0x0060D8C1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node54()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142E9 RID: 82665 RVA: 0x0060F4F8 File Offset: 0x0060D8F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC8F RID: 56463
		private int opl_p0;

		// Token: 0x0400DC90 RID: 56464
		private int opl_p1;

		// Token: 0x0400DC91 RID: 56465
		private int opl_p2;

		// Token: 0x0400DC92 RID: 56466
		private int opl_p3;
	}
}
