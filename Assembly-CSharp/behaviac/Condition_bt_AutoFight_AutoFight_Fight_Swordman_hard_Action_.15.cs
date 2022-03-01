using System;

namespace behaviac
{
	// Token: 0x020022AC RID: 8876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node31 : Condition
	{
		// Token: 0x06012ED4 RID: 77524 RVA: 0x0059567B File Offset: 0x00593A7B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node31()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012ED5 RID: 77525 RVA: 0x005956B0 File Offset: 0x00593AB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8DD RID: 51421
		private int opl_p0;

		// Token: 0x0400C8DE RID: 51422
		private int opl_p1;

		// Token: 0x0400C8DF RID: 51423
		private int opl_p2;

		// Token: 0x0400C8E0 RID: 51424
		private int opl_p3;
	}
}
