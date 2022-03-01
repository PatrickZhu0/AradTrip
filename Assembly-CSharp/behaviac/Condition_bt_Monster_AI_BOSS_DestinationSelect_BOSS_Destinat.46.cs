using System;

namespace behaviac
{
	// Token: 0x02002FF4 RID: 12276
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node5 : Condition
	{
		// Token: 0x060148B2 RID: 84146 RVA: 0x0062F40B File Offset: 0x0062D80B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node5()
		{
			this.opl_p0 = 0.55f;
		}

		// Token: 0x060148B3 RID: 84147 RVA: 0x0062F420 File Offset: 0x0062D820
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E210 RID: 57872
		private float opl_p0;
	}
}
