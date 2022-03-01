using System;

namespace behaviac
{
	// Token: 0x02002C9D RID: 11421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node34 : Condition
	{
		// Token: 0x06014231 RID: 82481 RVA: 0x0060C04D File Offset: 0x0060A44D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node34()
		{
			this.opl_p0 = 10500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06014232 RID: 82482 RVA: 0x0060C084 File Offset: 0x0060A484
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBE9 RID: 56297
		private int opl_p0;

		// Token: 0x0400DBEA RID: 56298
		private int opl_p1;

		// Token: 0x0400DBEB RID: 56299
		private int opl_p2;

		// Token: 0x0400DBEC RID: 56300
		private int opl_p3;
	}
}
