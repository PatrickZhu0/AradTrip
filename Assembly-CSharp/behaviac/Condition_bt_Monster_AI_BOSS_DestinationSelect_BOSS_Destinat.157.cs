using System;

namespace behaviac
{
	// Token: 0x020030A3 RID: 12451
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node29 : Condition
	{
		// Token: 0x06014A0A RID: 84490 RVA: 0x00635C3B File Offset: 0x0063403B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node29()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014A0B RID: 84491 RVA: 0x00635C50 File Offset: 0x00634050
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E367 RID: 58215
		private float opl_p0;
	}
}
