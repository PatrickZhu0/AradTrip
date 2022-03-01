using System;

namespace behaviac
{
	// Token: 0x020027D7 RID: 10199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node116 : Condition
	{
		// Token: 0x060138ED RID: 80109 RVA: 0x005D4F9A File Offset: 0x005D339A
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node116()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060138EE RID: 80110 RVA: 0x005D4FD0 File Offset: 0x005D33D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D34B RID: 54091
		private int opl_p0;

		// Token: 0x0400D34C RID: 54092
		private int opl_p1;

		// Token: 0x0400D34D RID: 54093
		private int opl_p2;

		// Token: 0x0400D34E RID: 54094
		private int opl_p3;
	}
}
