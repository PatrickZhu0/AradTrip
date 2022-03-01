using System;

namespace behaviac
{
	// Token: 0x02002FE8 RID: 12264
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node21 : Condition
	{
		// Token: 0x0601489B RID: 84123 RVA: 0x0062E897 File Offset: 0x0062CC97
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node21()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601489C RID: 84124 RVA: 0x0062E8AC File Offset: 0x0062CCAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1F9 RID: 57849
		private float opl_p0;
	}
}
