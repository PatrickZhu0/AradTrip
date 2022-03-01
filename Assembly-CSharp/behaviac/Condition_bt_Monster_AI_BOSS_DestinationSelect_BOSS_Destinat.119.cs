using System;

namespace behaviac
{
	// Token: 0x02003067 RID: 12391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node18 : Condition
	{
		// Token: 0x06014994 RID: 84372 RVA: 0x00633923 File Offset: 0x00631D23
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014995 RID: 84373 RVA: 0x00633958 File Offset: 0x00631D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2F1 RID: 58097
		private int opl_p0;

		// Token: 0x0400E2F2 RID: 58098
		private int opl_p1;

		// Token: 0x0400E2F3 RID: 58099
		private int opl_p2;

		// Token: 0x0400E2F4 RID: 58100
		private int opl_p3;
	}
}
