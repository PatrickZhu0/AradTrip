using System;

namespace behaviac
{
	// Token: 0x02002FB0 RID: 12208
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node10 : Condition
	{
		// Token: 0x0601482D RID: 84013 RVA: 0x0062C7D3 File Offset: 0x0062ABD3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601482E RID: 84014 RVA: 0x0062C808 File Offset: 0x0062AC08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E18A RID: 57738
		private int opl_p0;

		// Token: 0x0400E18B RID: 57739
		private int opl_p1;

		// Token: 0x0400E18C RID: 57740
		private int opl_p2;

		// Token: 0x0400E18D RID: 57741
		private int opl_p3;
	}
}
