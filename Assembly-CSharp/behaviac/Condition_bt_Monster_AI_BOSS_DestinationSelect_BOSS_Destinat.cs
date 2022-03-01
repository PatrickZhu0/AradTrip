using System;

namespace behaviac
{
	// Token: 0x02002FAC RID: 12204
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node5 : Condition
	{
		// Token: 0x06014825 RID: 84005 RVA: 0x0062C6A0 File Offset: 0x0062AAA0
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node5()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06014826 RID: 84006 RVA: 0x0062C6B4 File Offset: 0x0062AAB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E183 RID: 57731
		private float opl_p0;
	}
}
