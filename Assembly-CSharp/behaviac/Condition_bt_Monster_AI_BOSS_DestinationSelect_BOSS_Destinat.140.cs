using System;

namespace behaviac
{
	// Token: 0x02003088 RID: 12424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node29 : Condition
	{
		// Token: 0x060149D5 RID: 84437 RVA: 0x00634B43 File Offset: 0x00632F43
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node29()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149D6 RID: 84438 RVA: 0x00634B58 File Offset: 0x00632F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E332 RID: 58162
		private float opl_p0;
	}
}
