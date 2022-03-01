using System;

namespace behaviac
{
	// Token: 0x0200234E RID: 9038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node39 : Condition
	{
		// Token: 0x06013009 RID: 77833 RVA: 0x0059E9E5 File Offset: 0x0059CDE5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601300A RID: 77834 RVA: 0x0059EA04 File Offset: 0x0059CE04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA1F RID: 51743
		private BE_Target opl_p0;

		// Token: 0x0400CA20 RID: 51744
		private BE_Equal opl_p1;

		// Token: 0x0400CA21 RID: 51745
		private BE_State opl_p2;
	}
}
