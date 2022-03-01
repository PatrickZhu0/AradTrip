using System;

namespace behaviac
{
	// Token: 0x02003069 RID: 12393
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node21 : Condition
	{
		// Token: 0x06014998 RID: 84376 RVA: 0x006339C7 File Offset: 0x00631DC7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node21()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06014999 RID: 84377 RVA: 0x006339DC File Offset: 0x00631DDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2F6 RID: 58102
		private float opl_p0;
	}
}
