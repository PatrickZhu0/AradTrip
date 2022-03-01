using System;

namespace behaviac
{
	// Token: 0x02003051 RID: 12369
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node25 : Condition
	{
		// Token: 0x06014969 RID: 84329 RVA: 0x006329BB File Offset: 0x00630DBB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601496A RID: 84330 RVA: 0x006329D0 File Offset: 0x00630DD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2C7 RID: 58055
		private float opl_p0;
	}
}
