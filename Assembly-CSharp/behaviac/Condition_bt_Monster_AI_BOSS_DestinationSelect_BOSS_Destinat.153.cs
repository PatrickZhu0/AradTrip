using System;

namespace behaviac
{
	// Token: 0x0200309D RID: 12445
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node21 : Condition
	{
		// Token: 0x060149FE RID: 84478 RVA: 0x00635A63 File Offset: 0x00633E63
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_8_0guyuxi_DestinationSelect_node21()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060149FF RID: 84479 RVA: 0x00635A78 File Offset: 0x00633E78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E35B RID: 58203
		private float opl_p0;
	}
}
