using System;

namespace behaviac
{
	// Token: 0x02002777 RID: 10103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node21 : Condition
	{
		// Token: 0x0601382F RID: 79919 RVA: 0x005D0736 File Offset: 0x005CEB36
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node21()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013830 RID: 79920 RVA: 0x005D076C File Offset: 0x005CEB6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D28F RID: 53903
		private int opl_p0;

		// Token: 0x0400D290 RID: 53904
		private int opl_p1;

		// Token: 0x0400D291 RID: 53905
		private int opl_p2;

		// Token: 0x0400D292 RID: 53906
		private int opl_p3;
	}
}
