using System;

namespace behaviac
{
	// Token: 0x02003085 RID: 12421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node25 : Condition
	{
		// Token: 0x060149CF RID: 84431 RVA: 0x00634A57 File Offset: 0x00632E57
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149D0 RID: 84432 RVA: 0x00634A6C File Offset: 0x00632E6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E32C RID: 58156
		private float opl_p0;
	}
}
