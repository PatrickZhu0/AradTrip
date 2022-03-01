using System;

namespace behaviac
{
	// Token: 0x0200336B RID: 13163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node21 : Condition
	{
		// Token: 0x06014F35 RID: 85813 RVA: 0x0064FB36 File Offset: 0x0064DF36
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node21()
		{
			this.opl_p0 = 0.42f;
		}

		// Token: 0x06014F36 RID: 85814 RVA: 0x0064FB4C File Offset: 0x0064DF4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FF RID: 59391
		private float opl_p0;
	}
}
