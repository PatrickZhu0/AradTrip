using System;

namespace behaviac
{
	// Token: 0x02002FC4 RID: 12228
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node5 : Condition
	{
		// Token: 0x06014854 RID: 84052 RVA: 0x0062D5C3 File Offset: 0x0062B9C3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014855 RID: 84053 RVA: 0x0062D5D8 File Offset: 0x0062B9D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1B2 RID: 57778
		private float opl_p0;
	}
}
