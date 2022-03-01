using System;

namespace behaviac
{
	// Token: 0x02003368 RID: 13160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node18 : Condition
	{
		// Token: 0x06014F2F RID: 85807 RVA: 0x0064FA7A File Offset: 0x0064DE7A
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node18()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06014F30 RID: 85808 RVA: 0x0064FA90 File Offset: 0x0064DE90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FC RID: 59388
		private float opl_p0;
	}
}
