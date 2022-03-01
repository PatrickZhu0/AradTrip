using System;

namespace behaviac
{
	// Token: 0x0200285F RID: 10335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node96 : Condition
	{
		// Token: 0x060139FC RID: 80380 RVA: 0x005DA526 File Offset: 0x005D8926
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node96()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060139FD RID: 80381 RVA: 0x005DA55C File Offset: 0x005D895C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D454 RID: 54356
		private int opl_p0;

		// Token: 0x0400D455 RID: 54357
		private int opl_p1;

		// Token: 0x0400D456 RID: 54358
		private int opl_p2;

		// Token: 0x0400D457 RID: 54359
		private int opl_p3;
	}
}
