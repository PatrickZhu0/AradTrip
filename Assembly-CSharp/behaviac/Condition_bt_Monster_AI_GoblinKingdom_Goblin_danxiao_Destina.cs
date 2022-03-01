using System;

namespace behaviac
{
	// Token: 0x020032F7 RID: 13047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node19 : Condition
	{
		// Token: 0x06014E58 RID: 85592 RVA: 0x0064BF8E File Offset: 0x0064A38E
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node19()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06014E59 RID: 85593 RVA: 0x0064BFC4 File Offset: 0x0064A3C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E744 RID: 59204
		private int opl_p0;

		// Token: 0x0400E745 RID: 59205
		private int opl_p1;

		// Token: 0x0400E746 RID: 59206
		private int opl_p2;

		// Token: 0x0400E747 RID: 59207
		private int opl_p3;
	}
}
