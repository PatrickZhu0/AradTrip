using System;

namespace behaviac
{
	// Token: 0x02002D1A RID: 11546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node7 : Condition
	{
		// Token: 0x06014321 RID: 82721 RVA: 0x0061128F File Offset: 0x0060F68F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node7()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06014322 RID: 82722 RVA: 0x006112C4 File Offset: 0x0060F6C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCD5 RID: 56533
		private int opl_p0;

		// Token: 0x0400DCD6 RID: 56534
		private int opl_p1;

		// Token: 0x0400DCD7 RID: 56535
		private int opl_p2;

		// Token: 0x0400DCD8 RID: 56536
		private int opl_p3;
	}
}
