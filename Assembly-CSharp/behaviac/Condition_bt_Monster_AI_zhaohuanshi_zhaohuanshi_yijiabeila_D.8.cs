using System;

namespace behaviac
{
	// Token: 0x02004018 RID: 16408
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node17 : Condition
	{
		// Token: 0x06016793 RID: 92051 RVA: 0x006CD21B File Offset: 0x006CB61B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node17()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x06016794 RID: 92052 RVA: 0x006CD250 File Offset: 0x006CB650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFE1 RID: 65505
		private int opl_p0;

		// Token: 0x0400FFE2 RID: 65506
		private int opl_p1;

		// Token: 0x0400FFE3 RID: 65507
		private int opl_p2;

		// Token: 0x0400FFE4 RID: 65508
		private int opl_p3;
	}
}
