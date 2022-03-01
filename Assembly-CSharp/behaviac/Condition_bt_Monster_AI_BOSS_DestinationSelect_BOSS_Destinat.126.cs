using System;

namespace behaviac
{
	// Token: 0x02003072 RID: 12402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node33 : Condition
	{
		// Token: 0x060149AA RID: 84394 RVA: 0x00633C8B File Offset: 0x0063208B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node33()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060149AB RID: 84395 RVA: 0x00633CA0 File Offset: 0x006320A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E308 RID: 58120
		private float opl_p0;
	}
}
