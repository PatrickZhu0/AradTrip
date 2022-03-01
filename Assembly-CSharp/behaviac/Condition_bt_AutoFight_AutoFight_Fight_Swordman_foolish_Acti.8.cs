using System;

namespace behaviac
{
	// Token: 0x02002288 RID: 8840
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node17 : Condition
	{
		// Token: 0x06012E91 RID: 77457 RVA: 0x00593FB6 File Offset: 0x005923B6
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_foolish_Action_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012E92 RID: 77458 RVA: 0x00593FEC File Offset: 0x005923EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C89C RID: 51356
		private int opl_p0;

		// Token: 0x0400C89D RID: 51357
		private int opl_p1;

		// Token: 0x0400C89E RID: 51358
		private int opl_p2;

		// Token: 0x0400C89F RID: 51359
		private int opl_p3;
	}
}
