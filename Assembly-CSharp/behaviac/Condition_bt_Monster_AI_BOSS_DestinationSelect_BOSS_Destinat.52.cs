using System;

namespace behaviac
{
	// Token: 0x02002FFD RID: 12285
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node17 : Condition
	{
		// Token: 0x060148C4 RID: 84164 RVA: 0x0062F6CF File Offset: 0x0062DACF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node17()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060148C5 RID: 84165 RVA: 0x0062F6E4 File Offset: 0x0062DAE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E222 RID: 57890
		private float opl_p0;
	}
}
