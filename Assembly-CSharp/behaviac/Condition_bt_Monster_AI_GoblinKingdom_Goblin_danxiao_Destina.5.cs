using System;

namespace behaviac
{
	// Token: 0x020032FE RID: 13054
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node8 : Condition
	{
		// Token: 0x06014E66 RID: 85606 RVA: 0x0064C1B1 File Offset: 0x0064A5B1
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node8()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x06014E67 RID: 85607 RVA: 0x0064C1E8 File Offset: 0x0064A5E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E753 RID: 59219
		private int opl_p0;

		// Token: 0x0400E754 RID: 59220
		private int opl_p1;

		// Token: 0x0400E755 RID: 59221
		private int opl_p2;

		// Token: 0x0400E756 RID: 59222
		private int opl_p3;
	}
}
