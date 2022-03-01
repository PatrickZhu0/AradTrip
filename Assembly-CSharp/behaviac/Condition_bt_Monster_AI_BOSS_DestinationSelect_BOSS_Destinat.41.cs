using System;

namespace behaviac
{
	// Token: 0x02002FEB RID: 12267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node25 : Condition
	{
		// Token: 0x060148A1 RID: 84129 RVA: 0x0062E983 File Offset: 0x0062CD83
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node25()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060148A2 RID: 84130 RVA: 0x0062E998 File Offset: 0x0062CD98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1FF RID: 57855
		private float opl_p0;
	}
}
