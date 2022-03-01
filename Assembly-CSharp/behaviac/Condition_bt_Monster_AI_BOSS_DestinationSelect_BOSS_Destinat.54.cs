using System;

namespace behaviac
{
	// Token: 0x02003000 RID: 12288
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node21 : Condition
	{
		// Token: 0x060148CA RID: 84170 RVA: 0x0062F7BB File Offset: 0x0062DBBB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_2_0shixuemaoyao_DestinationSelect_node21()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148CB RID: 84171 RVA: 0x0062F7D0 File Offset: 0x0062DBD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E228 RID: 57896
		private float opl_p0;
	}
}
