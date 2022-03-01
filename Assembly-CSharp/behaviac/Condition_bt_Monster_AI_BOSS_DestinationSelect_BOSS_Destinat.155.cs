using System;

namespace behaviac
{
	// Token: 0x020030A0 RID: 12448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node25 : Condition
	{
		// Token: 0x06014A04 RID: 84484 RVA: 0x00635B4F File Offset: 0x00633F4F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014A05 RID: 84485 RVA: 0x00635B64 File Offset: 0x00633F64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E361 RID: 58209
		private float opl_p0;
	}
}
