using System;

namespace behaviac
{
	// Token: 0x02002ED6 RID: 11990
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node44 : Condition
	{
		// Token: 0x06014686 RID: 83590 RVA: 0x00622B93 File Offset: 0x00620F93
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node44()
		{
			this.opl_p0 = 13000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 1500;
		}

		// Token: 0x06014687 RID: 83591 RVA: 0x00622BC8 File Offset: 0x00620FC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFF6 RID: 57334
		private int opl_p0;

		// Token: 0x0400DFF7 RID: 57335
		private int opl_p1;

		// Token: 0x0400DFF8 RID: 57336
		private int opl_p2;

		// Token: 0x0400DFF9 RID: 57337
		private int opl_p3;
	}
}
