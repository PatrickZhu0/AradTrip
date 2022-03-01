using System;

namespace behaviac
{
	// Token: 0x02002FB5 RID: 12213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node17 : Condition
	{
		// Token: 0x06014837 RID: 84023 RVA: 0x0062C963 File Offset: 0x0062AD63
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014838 RID: 84024 RVA: 0x0062C978 File Offset: 0x0062AD78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E195 RID: 57749
		private float opl_p0;
	}
}
