using System;

namespace behaviac
{
	// Token: 0x02002D00 RID: 11520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node59 : Condition
	{
		// Token: 0x060142F0 RID: 82672 RVA: 0x0060F641 File Offset: 0x0060DA41
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node59()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142F1 RID: 82673 RVA: 0x0060F678 File Offset: 0x0060DA78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC96 RID: 56470
		private int opl_p0;

		// Token: 0x0400DC97 RID: 56471
		private int opl_p1;

		// Token: 0x0400DC98 RID: 56472
		private int opl_p2;

		// Token: 0x0400DC99 RID: 56473
		private int opl_p3;
	}
}
