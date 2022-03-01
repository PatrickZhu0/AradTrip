using System;

namespace behaviac
{
	// Token: 0x02002264 RID: 8804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node2 : Condition
	{
		// Token: 0x06012E4F RID: 77391 RVA: 0x0059285D File Offset: 0x00590C5D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012E50 RID: 77392 RVA: 0x00592894 File Offset: 0x00590C94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C85C RID: 51292
		private int opl_p0;

		// Token: 0x0400C85D RID: 51293
		private int opl_p1;

		// Token: 0x0400C85E RID: 51294
		private int opl_p2;

		// Token: 0x0400C85F RID: 51295
		private int opl_p3;
	}
}
