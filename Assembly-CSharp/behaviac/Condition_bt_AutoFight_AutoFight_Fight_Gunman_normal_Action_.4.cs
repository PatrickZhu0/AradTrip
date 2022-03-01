using System;

namespace behaviac
{
	// Token: 0x020021CF RID: 8655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node8 : Condition
	{
		// Token: 0x06012D2C RID: 77100 RVA: 0x0058A263 File Offset: 0x00588663
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D2D RID: 77101 RVA: 0x0058A298 File Offset: 0x00588698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C71E RID: 50974
		private int opl_p0;

		// Token: 0x0400C71F RID: 50975
		private int opl_p1;

		// Token: 0x0400C720 RID: 50976
		private int opl_p2;

		// Token: 0x0400C721 RID: 50977
		private int opl_p3;
	}
}
