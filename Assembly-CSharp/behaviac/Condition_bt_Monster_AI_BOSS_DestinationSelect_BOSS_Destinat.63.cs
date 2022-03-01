using System;

namespace behaviac
{
	// Token: 0x0200300F RID: 12303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node9 : Condition
	{
		// Token: 0x060148E7 RID: 84199 RVA: 0x0063041B File Offset: 0x0062E81B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_3_0luoleikainuo_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148E8 RID: 84200 RVA: 0x00630430 File Offset: 0x0062E830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E245 RID: 57925
		private float opl_p0;
	}
}
