using System;

namespace behaviac
{
	// Token: 0x02003048 RID: 12360
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node13 : Condition
	{
		// Token: 0x06014957 RID: 84311 RVA: 0x006326F7 File Offset: 0x00630AF7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014958 RID: 84312 RVA: 0x0063270C File Offset: 0x00630B0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2B5 RID: 58037
		private float opl_p0;
	}
}
