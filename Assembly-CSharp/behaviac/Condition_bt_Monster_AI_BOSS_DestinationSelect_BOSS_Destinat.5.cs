using System;

namespace behaviac
{
	// Token: 0x02002FB2 RID: 12210
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node13 : Condition
	{
		// Token: 0x06014831 RID: 84017 RVA: 0x0062C877 File Offset: 0x0062AC77
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node13()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014832 RID: 84018 RVA: 0x0062C88C File Offset: 0x0062AC8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E18F RID: 57743
		private float opl_p0;
	}
}
