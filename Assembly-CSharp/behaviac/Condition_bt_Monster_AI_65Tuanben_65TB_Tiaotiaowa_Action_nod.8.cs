using System;

namespace behaviac
{
	// Token: 0x02002CE2 RID: 11490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node32 : Condition
	{
		// Token: 0x060142B4 RID: 82612 RVA: 0x0060EB41 File Offset: 0x0060CF41
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node32()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142B5 RID: 82613 RVA: 0x0060EB78 File Offset: 0x0060CF78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC62 RID: 56418
		private int opl_p0;

		// Token: 0x0400DC63 RID: 56419
		private int opl_p1;

		// Token: 0x0400DC64 RID: 56420
		private int opl_p2;

		// Token: 0x0400DC65 RID: 56421
		private int opl_p3;
	}
}
