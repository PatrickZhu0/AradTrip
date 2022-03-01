using System;

namespace behaviac
{
	// Token: 0x02002CEA RID: 11498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node34 : Condition
	{
		// Token: 0x060142C4 RID: 82628 RVA: 0x0060EE41 File Offset: 0x0060D241
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node34()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060142C5 RID: 82629 RVA: 0x0060EE78 File Offset: 0x0060D278
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC70 RID: 56432
		private int opl_p0;

		// Token: 0x0400DC71 RID: 56433
		private int opl_p1;

		// Token: 0x0400DC72 RID: 56434
		private int opl_p2;

		// Token: 0x0400DC73 RID: 56435
		private int opl_p3;
	}
}
