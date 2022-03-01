using System;

namespace behaviac
{
	// Token: 0x02002C99 RID: 11417
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node33 : Condition
	{
		// Token: 0x06014229 RID: 82473 RVA: 0x0060BECD File Offset: 0x0060A2CD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node33()
		{
			this.opl_p0 = 8500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601422A RID: 82474 RVA: 0x0060BF04 File Offset: 0x0060A304
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBE2 RID: 56290
		private int opl_p0;

		// Token: 0x0400DBE3 RID: 56291
		private int opl_p1;

		// Token: 0x0400DBE4 RID: 56292
		private int opl_p2;

		// Token: 0x0400DBE5 RID: 56293
		private int opl_p3;
	}
}
