using System;

namespace behaviac
{
	// Token: 0x02002FC7 RID: 12231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node9 : Condition
	{
		// Token: 0x0601485A RID: 84058 RVA: 0x0062D6AF File Offset: 0x0062BAAF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node9()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601485B RID: 84059 RVA: 0x0062D6C4 File Offset: 0x0062BAC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B8 RID: 57784
		private float opl_p0;
	}
}
