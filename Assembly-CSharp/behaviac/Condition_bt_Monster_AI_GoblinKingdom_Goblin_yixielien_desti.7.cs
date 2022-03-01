using System;

namespace behaviac
{
	// Token: 0x02003367 RID: 13159
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node17 : Condition
	{
		// Token: 0x06014F2D RID: 85805 RVA: 0x0064FA31 File Offset: 0x0064DE31
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_yixielien_destination_node17()
		{
			this.opl_p0 = 30230011;
		}

		// Token: 0x06014F2E RID: 85806 RVA: 0x0064FA44 File Offset: 0x0064DE44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7FB RID: 59387
		private int opl_p0;
	}
}
