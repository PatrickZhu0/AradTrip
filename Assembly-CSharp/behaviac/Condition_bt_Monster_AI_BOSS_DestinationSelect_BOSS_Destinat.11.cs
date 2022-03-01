using System;

namespace behaviac
{
	// Token: 0x02002FBB RID: 12219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node25 : Condition
	{
		// Token: 0x06014843 RID: 84035 RVA: 0x0062CB3B File Offset: 0x0062AF3B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node25()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014844 RID: 84036 RVA: 0x0062CB50 File Offset: 0x0062AF50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1A1 RID: 57761
		private float opl_p0;
	}
}
