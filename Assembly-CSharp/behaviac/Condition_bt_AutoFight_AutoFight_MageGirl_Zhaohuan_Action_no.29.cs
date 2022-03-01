using System;

namespace behaviac
{
	// Token: 0x0200276F RID: 10095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node16 : Condition
	{
		// Token: 0x0601381F RID: 79903 RVA: 0x005D03CE File Offset: 0x005CE7CE
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node16()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013820 RID: 79904 RVA: 0x005D0404 File Offset: 0x005CE804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D27F RID: 53887
		private int opl_p0;

		// Token: 0x0400D280 RID: 53888
		private int opl_p1;

		// Token: 0x0400D281 RID: 53889
		private int opl_p2;

		// Token: 0x0400D282 RID: 53890
		private int opl_p3;
	}
}
