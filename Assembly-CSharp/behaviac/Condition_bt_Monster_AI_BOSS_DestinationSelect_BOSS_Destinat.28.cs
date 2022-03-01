using System;

namespace behaviac
{
	// Token: 0x02002FD6 RID: 12246
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node29 : Condition
	{
		// Token: 0x06014878 RID: 84088 RVA: 0x0062DB4B File Offset: 0x0062BF4B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node29()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014879 RID: 84089 RVA: 0x0062DB60 File Offset: 0x0062BF60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1D6 RID: 57814
		private float opl_p0;
	}
}
