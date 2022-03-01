using System;

namespace behaviac
{
	// Token: 0x02003082 RID: 12418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node21 : Condition
	{
		// Token: 0x060149C9 RID: 84425 RVA: 0x0063496B File Offset: 0x00632D6B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node21()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060149CA RID: 84426 RVA: 0x00634980 File Offset: 0x00632D80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E326 RID: 58150
		private float opl_p0;
	}
}
