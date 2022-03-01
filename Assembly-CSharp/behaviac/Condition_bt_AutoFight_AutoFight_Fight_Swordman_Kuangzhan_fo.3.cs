using System;

namespace behaviac
{
	// Token: 0x02002337 RID: 9015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node5 : Condition
	{
		// Token: 0x06012FDF RID: 77791 RVA: 0x0059E052 File Offset: 0x0059C452
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012FE0 RID: 77792 RVA: 0x0059E088 File Offset: 0x0059C488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9F7 RID: 51703
		private int opl_p0;

		// Token: 0x0400C9F8 RID: 51704
		private int opl_p1;

		// Token: 0x0400C9F9 RID: 51705
		private int opl_p2;

		// Token: 0x0400C9FA RID: 51706
		private int opl_p3;
	}
}
