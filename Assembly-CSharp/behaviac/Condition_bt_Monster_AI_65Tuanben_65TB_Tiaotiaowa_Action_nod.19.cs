using System;

namespace behaviac
{
	// Token: 0x02002CF8 RID: 11512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node49 : Condition
	{
		// Token: 0x060142E0 RID: 82656 RVA: 0x0060F341 File Offset: 0x0060D741
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node49()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060142E1 RID: 82657 RVA: 0x0060F378 File Offset: 0x0060D778
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC88 RID: 56456
		private int opl_p0;

		// Token: 0x0400DC89 RID: 56457
		private int opl_p1;

		// Token: 0x0400DC8A RID: 56458
		private int opl_p2;

		// Token: 0x0400DC8B RID: 56459
		private int opl_p3;
	}
}
