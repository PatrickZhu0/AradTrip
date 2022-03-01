using System;

namespace behaviac
{
	// Token: 0x02002FDF RID: 12255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node9 : Condition
	{
		// Token: 0x06014889 RID: 84105 RVA: 0x0062E5D3 File Offset: 0x0062C9D3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601488A RID: 84106 RVA: 0x0062E5E8 File Offset: 0x0062C9E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1E7 RID: 57831
		private float opl_p0;
	}
}
