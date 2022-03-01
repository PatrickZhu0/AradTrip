using System;

namespace behaviac
{
	// Token: 0x0200306C RID: 12396
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node25 : Condition
	{
		// Token: 0x0601499E RID: 84382 RVA: 0x00633AB3 File Offset: 0x00631EB3
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_6_0sawuta_DestinationSelect_node25()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601499F RID: 84383 RVA: 0x00633AC8 File Offset: 0x00631EC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E2FC RID: 58108
		private float opl_p0;
	}
}
