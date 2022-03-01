using System;

namespace behaviac
{
	// Token: 0x02002BAF RID: 11183
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node5 : Condition
	{
		// Token: 0x06014065 RID: 82021 RVA: 0x00603A82 File Offset: 0x00601E82
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node5()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014066 RID: 82022 RVA: 0x00603AB8 File Offset: 0x00601EB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA5D RID: 55901
		private int opl_p0;

		// Token: 0x0400DA5E RID: 55902
		private int opl_p1;

		// Token: 0x0400DA5F RID: 55903
		private int opl_p2;

		// Token: 0x0400DA60 RID: 55904
		private int opl_p3;
	}
}
