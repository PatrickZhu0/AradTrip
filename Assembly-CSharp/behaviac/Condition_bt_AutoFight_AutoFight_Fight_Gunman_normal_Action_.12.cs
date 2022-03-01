using System;

namespace behaviac
{
	// Token: 0x020021DF RID: 8671
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node28 : Condition
	{
		// Token: 0x06012D4C RID: 77132 RVA: 0x0058AA33 File Offset: 0x00588E33
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D4D RID: 77133 RVA: 0x0058AA68 File Offset: 0x00588E68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C73E RID: 51006
		private int opl_p0;

		// Token: 0x0400C73F RID: 51007
		private int opl_p1;

		// Token: 0x0400C740 RID: 51008
		private int opl_p2;

		// Token: 0x0400C741 RID: 51009
		private int opl_p3;
	}
}
