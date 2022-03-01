using System;

namespace behaviac
{
	// Token: 0x02002756 RID: 10070
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node61 : Condition
	{
		// Token: 0x060137ED RID: 79853 RVA: 0x005CF8BA File Offset: 0x005CDCBA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node61()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137EE RID: 79854 RVA: 0x005CF8F0 File Offset: 0x005CDCF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D24A RID: 53834
		private int opl_p0;

		// Token: 0x0400D24B RID: 53835
		private int opl_p1;

		// Token: 0x0400D24C RID: 53836
		private int opl_p2;

		// Token: 0x0400D24D RID: 53837
		private int opl_p3;
	}
}
