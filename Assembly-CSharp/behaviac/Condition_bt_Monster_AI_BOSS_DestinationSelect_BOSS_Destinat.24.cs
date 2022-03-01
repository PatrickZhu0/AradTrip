using System;

namespace behaviac
{
	// Token: 0x02002FD0 RID: 12240
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node21 : Condition
	{
		// Token: 0x0601486C RID: 84076 RVA: 0x0062D973 File Offset: 0x0062BD73
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node21()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601486D RID: 84077 RVA: 0x0062D988 File Offset: 0x0062BD88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1CA RID: 57802
		private float opl_p0;
	}
}
