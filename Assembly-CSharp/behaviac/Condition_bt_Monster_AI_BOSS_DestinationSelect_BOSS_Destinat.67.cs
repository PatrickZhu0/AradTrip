using System;

namespace behaviac
{
	// Token: 0x02003015 RID: 12309
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node17 : Condition
	{
		// Token: 0x060148F3 RID: 84211 RVA: 0x006305F3 File Offset: 0x0062E9F3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148F4 RID: 84212 RVA: 0x00630608 File Offset: 0x0062EA08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E251 RID: 57937
		private float opl_p0;
	}
}
