using System;

namespace behaviac
{
	// Token: 0x020021DB RID: 8667
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node23 : Condition
	{
		// Token: 0x06012D44 RID: 77124 RVA: 0x0058A897 File Offset: 0x00588C97
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012D45 RID: 77125 RVA: 0x0058A8CC File Offset: 0x00588CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C736 RID: 50998
		private int opl_p0;

		// Token: 0x0400C737 RID: 50999
		private int opl_p1;

		// Token: 0x0400C738 RID: 51000
		private int opl_p2;

		// Token: 0x0400C739 RID: 51001
		private int opl_p3;
	}
}
