using System;

namespace behaviac
{
	// Token: 0x0200306F RID: 12399
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node29 : Condition
	{
		// Token: 0x060149A4 RID: 84388 RVA: 0x00633B9F File Offset: 0x00631F9F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node29()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x060149A5 RID: 84389 RVA: 0x00633BB4 File Offset: 0x00631FB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E302 RID: 58114
		private float opl_p0;
	}
}
