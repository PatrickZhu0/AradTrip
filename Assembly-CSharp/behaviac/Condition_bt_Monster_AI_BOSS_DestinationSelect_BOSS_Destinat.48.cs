using System;

namespace behaviac
{
	// Token: 0x02002FF7 RID: 12279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node9 : Condition
	{
		// Token: 0x060148B8 RID: 84152 RVA: 0x0062F4F7 File Offset: 0x0062D8F7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node9()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148B9 RID: 84153 RVA: 0x0062F50C File Offset: 0x0062D90C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E216 RID: 57878
		private float opl_p0;
	}
}
