using System;

namespace behaviac
{
	// Token: 0x02001F84 RID: 8068
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node18 : Condition
	{
		// Token: 0x060128A8 RID: 75944 RVA: 0x0056DFF7 File Offset: 0x0056C3F7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128A9 RID: 75945 RVA: 0x0056E02C File Offset: 0x0056C42C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C299 RID: 49817
		private int opl_p0;

		// Token: 0x0400C29A RID: 49818
		private int opl_p1;

		// Token: 0x0400C29B RID: 49819
		private int opl_p2;

		// Token: 0x0400C29C RID: 49820
		private int opl_p3;
	}
}
