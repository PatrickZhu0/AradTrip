using System;

namespace behaviac
{
	// Token: 0x0200279B RID: 10139
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node17 : Condition
	{
		// Token: 0x06013876 RID: 79990 RVA: 0x005D28C6 File Offset: 0x005D0CC6
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node17()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013877 RID: 79991 RVA: 0x005D28FC File Offset: 0x005D0CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2D5 RID: 53973
		private int opl_p0;

		// Token: 0x0400D2D6 RID: 53974
		private int opl_p1;

		// Token: 0x0400D2D7 RID: 53975
		private int opl_p2;

		// Token: 0x0400D2D8 RID: 53976
		private int opl_p3;
	}
}
