using System;

namespace behaviac
{
	// Token: 0x02002FAF RID: 12207
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node9 : Condition
	{
		// Token: 0x0601482B RID: 84011 RVA: 0x0062C78B File Offset: 0x0062AB8B
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601482C RID: 84012 RVA: 0x0062C7A0 File Offset: 0x0062ABA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E189 RID: 57737
		private float opl_p0;
	}
}
