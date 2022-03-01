using System;

namespace behaviac
{
	// Token: 0x02002CE6 RID: 11494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node33 : Condition
	{
		// Token: 0x060142BC RID: 82620 RVA: 0x0060ECC1 File Offset: 0x0060D0C1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node33()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142BD RID: 82621 RVA: 0x0060ECF8 File Offset: 0x0060D0F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC69 RID: 56425
		private int opl_p0;

		// Token: 0x0400DC6A RID: 56426
		private int opl_p1;

		// Token: 0x0400DC6B RID: 56427
		private int opl_p2;

		// Token: 0x0400DC6C RID: 56428
		private int opl_p3;
	}
}
