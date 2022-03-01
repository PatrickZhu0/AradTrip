using System;

namespace behaviac
{
	// Token: 0x0200307C RID: 12412
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node13 : Condition
	{
		// Token: 0x060149BD RID: 84413 RVA: 0x00634793 File Offset: 0x00632B93
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060149BE RID: 84414 RVA: 0x006347A8 File Offset: 0x00632BA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E31A RID: 58138
		private float opl_p0;
	}
}
