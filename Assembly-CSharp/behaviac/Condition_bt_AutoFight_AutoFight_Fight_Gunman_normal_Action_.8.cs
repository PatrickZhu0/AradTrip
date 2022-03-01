using System;

namespace behaviac
{
	// Token: 0x020021D7 RID: 8663
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node18 : Condition
	{
		// Token: 0x06012D3C RID: 77116 RVA: 0x0058A64B File Offset: 0x00588A4B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D3D RID: 77117 RVA: 0x0058A680 File Offset: 0x00588A80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C72E RID: 50990
		private int opl_p0;

		// Token: 0x0400C72F RID: 50991
		private int opl_p1;

		// Token: 0x0400C730 RID: 50992
		private int opl_p2;

		// Token: 0x0400C731 RID: 50993
		private int opl_p3;
	}
}
