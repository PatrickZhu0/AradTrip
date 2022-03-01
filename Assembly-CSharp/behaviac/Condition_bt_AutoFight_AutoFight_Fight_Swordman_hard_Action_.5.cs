using System;

namespace behaviac
{
	// Token: 0x0200229C RID: 8860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node5 : Condition
	{
		// Token: 0x06012EB6 RID: 77494 RVA: 0x00595056 File Offset: 0x00593456
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node5()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012EB7 RID: 77495 RVA: 0x0059508C File Offset: 0x0059348C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8C1 RID: 51393
		private int opl_p0;

		// Token: 0x0400C8C2 RID: 51394
		private int opl_p1;

		// Token: 0x0400C8C3 RID: 51395
		private int opl_p2;

		// Token: 0x0400C8C4 RID: 51396
		private int opl_p3;
	}
}
