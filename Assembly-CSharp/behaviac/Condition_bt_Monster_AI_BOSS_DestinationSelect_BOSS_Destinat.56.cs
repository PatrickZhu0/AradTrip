using System;

namespace behaviac
{
	// Token: 0x02003003 RID: 12291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node25 : Condition
	{
		// Token: 0x060148D0 RID: 84176 RVA: 0x0062F8A7 File Offset: 0x0062DCA7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148D1 RID: 84177 RVA: 0x0062F8BC File Offset: 0x0062DCBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E22E RID: 57902
		private float opl_p0;
	}
}
