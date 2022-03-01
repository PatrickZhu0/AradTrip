using System;

namespace behaviac
{
	// Token: 0x0200226F RID: 8815
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node17 : Condition
	{
		// Token: 0x06012E63 RID: 77411 RVA: 0x00592D4E File Offset: 0x0059114E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012E64 RID: 77412 RVA: 0x00592D84 File Offset: 0x00591184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C86F RID: 51311
		private int opl_p0;

		// Token: 0x0400C870 RID: 51312
		private int opl_p1;

		// Token: 0x0400C871 RID: 51313
		private int opl_p2;

		// Token: 0x0400C872 RID: 51314
		private int opl_p3;
	}
}
