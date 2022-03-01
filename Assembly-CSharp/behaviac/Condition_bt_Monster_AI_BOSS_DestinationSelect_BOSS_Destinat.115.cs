using System;

namespace behaviac
{
	// Token: 0x02003061 RID: 12385
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node10 : Condition
	{
		// Token: 0x06014988 RID: 84360 RVA: 0x0063374B File Offset: 0x00631B4B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014989 RID: 84361 RVA: 0x00633780 File Offset: 0x00631B80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2E5 RID: 58085
		private int opl_p0;

		// Token: 0x0400E2E6 RID: 58086
		private int opl_p1;

		// Token: 0x0400E2E7 RID: 58087
		private int opl_p2;

		// Token: 0x0400E2E8 RID: 58088
		private int opl_p3;
	}
}
