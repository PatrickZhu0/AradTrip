using System;

namespace behaviac
{
	// Token: 0x0200309A RID: 12442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node17 : Condition
	{
		// Token: 0x060149F8 RID: 84472 RVA: 0x00635977 File Offset: 0x00633D77
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060149F9 RID: 84473 RVA: 0x0063598C File Offset: 0x00633D8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E355 RID: 58197
		private float opl_p0;
	}
}
