using System;

namespace behaviac
{
	// Token: 0x020032FA RID: 13050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node6 : Condition
	{
		// Token: 0x06014E5E RID: 85598 RVA: 0x0064C079 File Offset: 0x0064A479
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014E5F RID: 85599 RVA: 0x0064C0B0 File Offset: 0x0064A4B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E74A RID: 59210
		private int opl_p0;

		// Token: 0x0400E74B RID: 59211
		private int opl_p1;

		// Token: 0x0400E74C RID: 59212
		private int opl_p2;

		// Token: 0x0400E74D RID: 59213
		private int opl_p3;
	}
}
