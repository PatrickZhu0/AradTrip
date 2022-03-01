using System;

namespace behaviac
{
	// Token: 0x02003076 RID: 12406
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node5 : Condition
	{
		// Token: 0x060149B1 RID: 84401 RVA: 0x006345BB File Offset: 0x006329BB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_7_0binuoxiu_DestinationSelect_node5()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060149B2 RID: 84402 RVA: 0x006345D0 File Offset: 0x006329D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E30E RID: 58126
		private float opl_p0;
	}
}
