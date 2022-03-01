using System;

namespace behaviac
{
	// Token: 0x02003AFC RID: 15100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4 : Condition
	{
		// Token: 0x06015DB4 RID: 89524 RVA: 0x0069AA4F File Offset: 0x00698E4F
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015DB5 RID: 89525 RVA: 0x0069AA84 File Offset: 0x00698E84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6AD RID: 63149
		private int opl_p0;

		// Token: 0x0400F6AE RID: 63150
		private int opl_p1;

		// Token: 0x0400F6AF RID: 63151
		private int opl_p2;

		// Token: 0x0400F6B0 RID: 63152
		private int opl_p3;
	}
}
