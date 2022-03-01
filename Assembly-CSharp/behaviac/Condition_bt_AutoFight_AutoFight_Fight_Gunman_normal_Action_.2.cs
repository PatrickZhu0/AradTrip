using System;

namespace behaviac
{
	// Token: 0x020021CB RID: 8651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node3 : Condition
	{
		// Token: 0x06012D24 RID: 77092 RVA: 0x0058A017 File Offset: 0x00588417
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D25 RID: 77093 RVA: 0x0058A04C File Offset: 0x0058844C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C716 RID: 50966
		private int opl_p0;

		// Token: 0x0400C717 RID: 50967
		private int opl_p1;

		// Token: 0x0400C718 RID: 50968
		private int opl_p2;

		// Token: 0x0400C719 RID: 50969
		private int opl_p3;
	}
}
