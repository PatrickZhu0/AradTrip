using System;

namespace behaviac
{
	// Token: 0x02002FB8 RID: 12216
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node21 : Condition
	{
		// Token: 0x0601483D RID: 84029 RVA: 0x0062CA4F File Offset: 0x0062AE4F
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node21()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601483E RID: 84030 RVA: 0x0062CA64 File Offset: 0x0062AE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E19B RID: 57755
		private float opl_p0;
	}
}
