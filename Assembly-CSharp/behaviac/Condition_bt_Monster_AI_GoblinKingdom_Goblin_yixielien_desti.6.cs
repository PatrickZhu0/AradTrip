using System;

namespace behaviac
{
	// Token: 0x02003365 RID: 13157
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node13 : Condition
	{
		// Token: 0x06014F29 RID: 85801 RVA: 0x0064F9BE File Offset: 0x0064DDBE
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node13()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x06014F2A RID: 85802 RVA: 0x0064F9D4 File Offset: 0x0064DDD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F9 RID: 59385
		private float opl_p0;
	}
}
