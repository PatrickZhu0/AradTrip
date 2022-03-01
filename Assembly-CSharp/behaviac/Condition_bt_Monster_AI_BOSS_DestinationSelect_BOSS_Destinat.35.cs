using System;

namespace behaviac
{
	// Token: 0x02002FE2 RID: 12258
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601488F RID: 84111 RVA: 0x0062E6BF File Offset: 0x0062CABF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node13()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014890 RID: 84112 RVA: 0x0062E6D4 File Offset: 0x0062CAD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1ED RID: 57837
		private float opl_p0;
	}
}
