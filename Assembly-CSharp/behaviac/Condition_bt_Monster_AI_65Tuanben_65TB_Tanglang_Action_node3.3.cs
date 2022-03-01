using System;

namespace behaviac
{
	// Token: 0x02002C95 RID: 11413
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node32 : Condition
	{
		// Token: 0x06014221 RID: 82465 RVA: 0x0060BD4D File Offset: 0x0060A14D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node32()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06014222 RID: 82466 RVA: 0x0060BD84 File Offset: 0x0060A184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBDB RID: 56283
		private int opl_p0;

		// Token: 0x0400DBDC RID: 56284
		private int opl_p1;

		// Token: 0x0400DBDD RID: 56285
		private int opl_p2;

		// Token: 0x0400DBDE RID: 56286
		private int opl_p3;
	}
}
