using System;

namespace behaviac
{
	// Token: 0x0200227A RID: 8826
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node31 : Condition
	{
		// Token: 0x06012E78 RID: 77432 RVA: 0x005931AF File Offset: 0x005915AF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node31()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012E79 RID: 77433 RVA: 0x005931E4 File Offset: 0x005915E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C883 RID: 51331
		private int opl_p0;

		// Token: 0x0400C884 RID: 51332
		private int opl_p1;

		// Token: 0x0400C885 RID: 51333
		private int opl_p2;

		// Token: 0x0400C886 RID: 51334
		private int opl_p3;
	}
}
