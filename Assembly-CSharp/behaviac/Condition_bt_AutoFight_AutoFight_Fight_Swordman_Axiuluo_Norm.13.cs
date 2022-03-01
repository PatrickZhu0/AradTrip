using System;

namespace behaviac
{
	// Token: 0x02002251 RID: 8785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node53 : Condition
	{
		// Token: 0x06012E2A RID: 77354 RVA: 0x005911D0 File Offset: 0x0058F5D0
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node53()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012E2B RID: 77355 RVA: 0x00591204 File Offset: 0x0058F604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C82E RID: 51246
		private int opl_p0;

		// Token: 0x0400C82F RID: 51247
		private int opl_p1;

		// Token: 0x0400C830 RID: 51248
		private int opl_p2;

		// Token: 0x0400C831 RID: 51249
		private int opl_p3;
	}
}
