using System;

namespace behaviac
{
	// Token: 0x02002FCA RID: 12234
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node13 : Condition
	{
		// Token: 0x06014860 RID: 84064 RVA: 0x0062D79B File Offset: 0x0062BB9B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node13()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014861 RID: 84065 RVA: 0x0062D7B0 File Offset: 0x0062BBB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1BE RID: 57790
		private float opl_p0;
	}
}
