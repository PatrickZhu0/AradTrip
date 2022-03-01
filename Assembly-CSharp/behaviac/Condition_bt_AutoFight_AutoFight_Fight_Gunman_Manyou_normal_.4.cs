using System;

namespace behaviac
{
	// Token: 0x0200217F RID: 8575
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node8 : Condition
	{
		// Token: 0x06012C8E RID: 76942 RVA: 0x0058657B File Offset: 0x0058497B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012C8F RID: 76943 RVA: 0x005865B0 File Offset: 0x005849B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C680 RID: 50816
		private int opl_p0;

		// Token: 0x0400C681 RID: 50817
		private int opl_p1;

		// Token: 0x0400C682 RID: 50818
		private int opl_p2;

		// Token: 0x0400C683 RID: 50819
		private int opl_p3;
	}
}
