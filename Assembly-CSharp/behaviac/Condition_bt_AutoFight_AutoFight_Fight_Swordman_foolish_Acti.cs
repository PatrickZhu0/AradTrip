using System;

namespace behaviac
{
	// Token: 0x0200227D RID: 8829
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node2 : Condition
	{
		// Token: 0x06012E7D RID: 77437 RVA: 0x00593AC5 File Offset: 0x00591EC5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012E7E RID: 77438 RVA: 0x00593AFC File Offset: 0x00591EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C889 RID: 51337
		private int opl_p0;

		// Token: 0x0400C88A RID: 51338
		private int opl_p1;

		// Token: 0x0400C88B RID: 51339
		private int opl_p2;

		// Token: 0x0400C88C RID: 51340
		private int opl_p3;
	}
}
