using System;

namespace behaviac
{
	// Token: 0x020040C5 RID: 16581
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node5 : Condition
	{
		// Token: 0x060168E1 RID: 92385 RVA: 0x006D4943 File Offset: 0x006D2D43
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node5()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060168E2 RID: 92386 RVA: 0x006D4978 File Offset: 0x006D2D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010126 RID: 65830
		private int opl_p0;

		// Token: 0x04010127 RID: 65831
		private int opl_p1;

		// Token: 0x04010128 RID: 65832
		private int opl_p2;

		// Token: 0x04010129 RID: 65833
		private int opl_p3;
	}
}
