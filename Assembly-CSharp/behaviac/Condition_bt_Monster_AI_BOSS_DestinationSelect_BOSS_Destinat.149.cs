using System;

namespace behaviac
{
	// Token: 0x02003097 RID: 12439
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node13 : Condition
	{
		// Token: 0x060149F2 RID: 84466 RVA: 0x0063588B File Offset: 0x00633C8B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060149F3 RID: 84467 RVA: 0x006358A0 File Offset: 0x00633CA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E34F RID: 58191
		private float opl_p0;
	}
}
