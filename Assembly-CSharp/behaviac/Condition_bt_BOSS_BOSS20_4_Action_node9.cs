using System;

namespace behaviac
{
	// Token: 0x020029EB RID: 10731
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node9 : Condition
	{
		// Token: 0x06013D09 RID: 81161 RVA: 0x005EE382 File Offset: 0x005EC782
		public Condition_bt_BOSS_BOSS20_4_Action_node9()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013D0A RID: 81162 RVA: 0x005EE3B8 File Offset: 0x005EC7B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D77C RID: 55164
		private int opl_p0;

		// Token: 0x0400D77D RID: 55165
		private int opl_p1;

		// Token: 0x0400D77E RID: 55166
		private int opl_p2;

		// Token: 0x0400D77F RID: 55167
		private int opl_p3;
	}
}
