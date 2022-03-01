using System;

namespace behaviac
{
	// Token: 0x02002FFA RID: 12282
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node13 : Condition
	{
		// Token: 0x060148BE RID: 84158 RVA: 0x0062F5E3 File Offset: 0x0062D9E3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node13()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148BF RID: 84159 RVA: 0x0062F5F8 File Offset: 0x0062D9F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E21C RID: 57884
		private float opl_p0;
	}
}
