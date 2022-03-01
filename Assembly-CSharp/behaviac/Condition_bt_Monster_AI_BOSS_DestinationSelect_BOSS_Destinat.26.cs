using System;

namespace behaviac
{
	// Token: 0x02002FD3 RID: 12243
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node25 : Condition
	{
		// Token: 0x06014872 RID: 84082 RVA: 0x0062DA5F File Offset: 0x0062BE5F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node25()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014873 RID: 84083 RVA: 0x0062DA74 File Offset: 0x0062BE74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1D0 RID: 57808
		private float opl_p0;
	}
}
