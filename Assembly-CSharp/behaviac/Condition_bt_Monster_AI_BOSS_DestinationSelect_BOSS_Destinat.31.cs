using System;

namespace behaviac
{
	// Token: 0x02002FDC RID: 12252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node5 : Condition
	{
		// Token: 0x06014883 RID: 84099 RVA: 0x0062E4E7 File Offset: 0x0062C8E7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014884 RID: 84100 RVA: 0x0062E4FC File Offset: 0x0062C8FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E1 RID: 57825
		private float opl_p0;
	}
}
