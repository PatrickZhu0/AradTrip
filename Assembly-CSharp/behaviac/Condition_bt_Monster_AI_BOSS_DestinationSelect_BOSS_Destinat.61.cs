using System;

namespace behaviac
{
	// Token: 0x0200300C RID: 12300
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node5 : Condition
	{
		// Token: 0x060148E1 RID: 84193 RVA: 0x0063032F File Offset: 0x0062E72F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060148E2 RID: 84194 RVA: 0x00630344 File Offset: 0x0062E744
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E23F RID: 57919
		private float opl_p0;
	}
}
