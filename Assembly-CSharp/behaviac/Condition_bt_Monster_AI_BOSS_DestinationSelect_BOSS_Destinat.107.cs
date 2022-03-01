using System;

namespace behaviac
{
	// Token: 0x02003054 RID: 12372
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node29 : Condition
	{
		// Token: 0x0601496F RID: 84335 RVA: 0x00632AA7 File Offset: 0x00630EA7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_5_0kelahe_DestinationSelect_node29()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014970 RID: 84336 RVA: 0x00632ABC File Offset: 0x00630EBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2CD RID: 58061
		private float opl_p0;
	}
}
