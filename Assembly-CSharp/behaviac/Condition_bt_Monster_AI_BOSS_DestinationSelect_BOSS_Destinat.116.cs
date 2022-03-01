using System;

namespace behaviac
{
	// Token: 0x02003063 RID: 12387
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node13 : Condition
	{
		// Token: 0x0601498C RID: 84364 RVA: 0x006337EF File Offset: 0x00631BEF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node13()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601498D RID: 84365 RVA: 0x00633804 File Offset: 0x00631C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2EA RID: 58090
		private float opl_p0;
	}
}
