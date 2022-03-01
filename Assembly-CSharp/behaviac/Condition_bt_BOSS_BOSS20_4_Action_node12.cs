using System;

namespace behaviac
{
	// Token: 0x020029DD RID: 10717
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node12 : Condition
	{
		// Token: 0x06013CED RID: 81133 RVA: 0x005EDD9D File Offset: 0x005EC19D
		public Condition_bt_BOSS_BOSS20_4_Action_node12()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013CEE RID: 81134 RVA: 0x005EDDD4 File Offset: 0x005EC1D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D75E RID: 55134
		private int opl_p0;

		// Token: 0x0400D75F RID: 55135
		private int opl_p1;

		// Token: 0x0400D760 RID: 55136
		private int opl_p2;

		// Token: 0x0400D761 RID: 55137
		private int opl_p3;
	}
}
