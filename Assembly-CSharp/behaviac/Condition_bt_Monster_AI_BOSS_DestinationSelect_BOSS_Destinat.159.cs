using System;

namespace behaviac
{
	// Token: 0x020030A6 RID: 12454
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node33 : Condition
	{
		// Token: 0x06014A10 RID: 84496 RVA: 0x00635D27 File Offset: 0x00634127
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014A11 RID: 84497 RVA: 0x00635D3C File Offset: 0x0063413C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E36D RID: 58221
		private float opl_p0;
	}
}
