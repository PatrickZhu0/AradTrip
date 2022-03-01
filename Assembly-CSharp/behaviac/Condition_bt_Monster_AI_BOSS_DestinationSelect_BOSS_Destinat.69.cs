using System;

namespace behaviac
{
	// Token: 0x02003018 RID: 12312
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node21 : Condition
	{
		// Token: 0x060148F9 RID: 84217 RVA: 0x006306DF File Offset: 0x0062EADF
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node21()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060148FA RID: 84218 RVA: 0x006306F4 File Offset: 0x0062EAF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E257 RID: 57943
		private float opl_p0;
	}
}
