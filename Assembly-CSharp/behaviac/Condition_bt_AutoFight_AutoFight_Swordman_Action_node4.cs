using System;

namespace behaviac
{
	// Token: 0x0200286C RID: 10348
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node4 : Condition
	{
		// Token: 0x06013A15 RID: 80405 RVA: 0x005DC573 File Offset: 0x005DA973
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node4()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013A16 RID: 80406 RVA: 0x005DC5A8 File Offset: 0x005DA9A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D46C RID: 54380
		private int opl_p0;

		// Token: 0x0400D46D RID: 54381
		private int opl_p1;

		// Token: 0x0400D46E RID: 54382
		private int opl_p2;

		// Token: 0x0400D46F RID: 54383
		private int opl_p3;
	}
}
