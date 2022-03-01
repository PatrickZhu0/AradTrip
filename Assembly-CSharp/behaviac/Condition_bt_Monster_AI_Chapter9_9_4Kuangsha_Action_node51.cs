using System;

namespace behaviac
{
	// Token: 0x0200317E RID: 12670
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node51 : Condition
	{
		// Token: 0x06014B93 RID: 84883 RVA: 0x0063D663 File Offset: 0x0063BA63
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node51()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06014B94 RID: 84884 RVA: 0x0063D698 File Offset: 0x0063BA98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4FD RID: 58621
		private int opl_p0;

		// Token: 0x0400E4FE RID: 58622
		private int opl_p1;

		// Token: 0x0400E4FF RID: 58623
		private int opl_p2;

		// Token: 0x0400E500 RID: 58624
		private int opl_p3;
	}
}
