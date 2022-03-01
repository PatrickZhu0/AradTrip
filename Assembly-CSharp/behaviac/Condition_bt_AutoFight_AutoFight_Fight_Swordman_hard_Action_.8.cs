using System;

namespace behaviac
{
	// Token: 0x020022A1 RID: 8865
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node17 : Condition
	{
		// Token: 0x06012EBF RID: 77503 RVA: 0x0059521A File Offset: 0x0059361A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012EC0 RID: 77504 RVA: 0x00595250 File Offset: 0x00593650
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8C9 RID: 51401
		private int opl_p0;

		// Token: 0x0400C8CA RID: 51402
		private int opl_p1;

		// Token: 0x0400C8CB RID: 51403
		private int opl_p2;

		// Token: 0x0400C8CC RID: 51404
		private int opl_p3;
	}
}
