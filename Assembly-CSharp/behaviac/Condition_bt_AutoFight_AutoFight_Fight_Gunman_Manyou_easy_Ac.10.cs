using System;

namespace behaviac
{
	// Token: 0x02002113 RID: 8467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node23 : Condition
	{
		// Token: 0x06012BB9 RID: 76729 RVA: 0x005810AB File Offset: 0x0057F4AB
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BBA RID: 76730 RVA: 0x005810E0 File Offset: 0x0057F4E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5AB RID: 50603
		private int opl_p0;

		// Token: 0x0400C5AC RID: 50604
		private int opl_p1;

		// Token: 0x0400C5AD RID: 50605
		private int opl_p2;

		// Token: 0x0400C5AE RID: 50606
		private int opl_p3;
	}
}
