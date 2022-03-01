using System;

namespace behaviac
{
	// Token: 0x02002C91 RID: 11409
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node29 : Condition
	{
		// Token: 0x06014219 RID: 82457 RVA: 0x0060BBCD File Offset: 0x00609FCD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node29()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601421A RID: 82458 RVA: 0x0060BC04 File Offset: 0x0060A004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBD4 RID: 56276
		private int opl_p0;

		// Token: 0x0400DBD5 RID: 56277
		private int opl_p1;

		// Token: 0x0400DBD6 RID: 56278
		private int opl_p2;

		// Token: 0x0400DBD7 RID: 56279
		private int opl_p3;
	}
}
