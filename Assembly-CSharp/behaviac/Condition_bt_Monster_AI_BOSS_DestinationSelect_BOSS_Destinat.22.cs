using System;

namespace behaviac
{
	// Token: 0x02002FCD RID: 12237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node17 : Condition
	{
		// Token: 0x06014866 RID: 84070 RVA: 0x0062D887 File Offset: 0x0062BC87
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node17()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014867 RID: 84071 RVA: 0x0062D89C File Offset: 0x0062BC9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1C4 RID: 57796
		private float opl_p0;
	}
}
