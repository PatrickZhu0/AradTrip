using System;

namespace behaviac
{
	// Token: 0x02002724 RID: 10020
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node53 : Condition
	{
		// Token: 0x0601378A RID: 79754 RVA: 0x005CCEBA File Offset: 0x005CB2BA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node53()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601378B RID: 79755 RVA: 0x005CCEF0 File Offset: 0x005CB2F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E3 RID: 53731
		private int opl_p0;

		// Token: 0x0400D1E4 RID: 53732
		private int opl_p1;

		// Token: 0x0400D1E5 RID: 53733
		private int opl_p2;

		// Token: 0x0400D1E6 RID: 53734
		private int opl_p3;
	}
}
