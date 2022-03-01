using System;

namespace behaviac
{
	// Token: 0x02002FE5 RID: 12261
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node17 : Condition
	{
		// Token: 0x06014895 RID: 84117 RVA: 0x0062E7AB File Offset: 0x0062CBAB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node17()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014896 RID: 84118 RVA: 0x0062E7C0 File Offset: 0x0062CBC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1F3 RID: 57843
		private float opl_p0;
	}
}
