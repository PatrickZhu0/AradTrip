using System;

namespace behaviac
{
	// Token: 0x02003066 RID: 12390
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node17 : Condition
	{
		// Token: 0x06014992 RID: 84370 RVA: 0x006338DB File Offset: 0x00631CDB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node17()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014993 RID: 84371 RVA: 0x006338F0 File Offset: 0x00631CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2F0 RID: 58096
		private float opl_p0;
	}
}
