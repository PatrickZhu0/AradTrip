using System;

namespace behaviac
{
	// Token: 0x02002CF0 RID: 11504
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node39 : Condition
	{
		// Token: 0x060142D0 RID: 82640 RVA: 0x0060F043 File Offset: 0x0060D443
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node39()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x060142D1 RID: 82641 RVA: 0x0060F078 File Offset: 0x0060D478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC7A RID: 56442
		private int opl_p0;

		// Token: 0x0400DC7B RID: 56443
		private int opl_p1;

		// Token: 0x0400DC7C RID: 56444
		private int opl_p2;

		// Token: 0x0400DC7D RID: 56445
		private int opl_p3;
	}
}
