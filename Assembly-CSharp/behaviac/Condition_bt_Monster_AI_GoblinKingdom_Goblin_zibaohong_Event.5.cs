using System;

namespace behaviac
{
	// Token: 0x02003373 RID: 13171
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node7 : Condition
	{
		// Token: 0x06014F44 RID: 85828 RVA: 0x006502FF File Offset: 0x0064E6FF
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node7()
		{
			this.opl_p0 = 5697;
		}

		// Token: 0x06014F45 RID: 85829 RVA: 0x00650314 File Offset: 0x0064E714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E80C RID: 59404
		private int opl_p0;
	}
}
