using System;

namespace behaviac
{
	// Token: 0x0200305D RID: 12381
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node5 : Condition
	{
		// Token: 0x06014980 RID: 84352 RVA: 0x00633618 File Offset: 0x00631A18
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node5()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014981 RID: 84353 RVA: 0x0063362C File Offset: 0x00631A2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2DE RID: 58078
		private float opl_p0;
	}
}
