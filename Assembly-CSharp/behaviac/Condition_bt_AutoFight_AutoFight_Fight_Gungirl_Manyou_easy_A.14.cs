using System;

namespace behaviac
{
	// Token: 0x02001FD8 RID: 8152
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node33 : Condition
	{
		// Token: 0x0601294D RID: 76109 RVA: 0x00571D3B File Offset: 0x0057013B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601294E RID: 76110 RVA: 0x00571D70 File Offset: 0x00570170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C33E RID: 49982
		private int opl_p0;

		// Token: 0x0400C33F RID: 49983
		private int opl_p1;

		// Token: 0x0400C340 RID: 49984
		private int opl_p2;

		// Token: 0x0400C341 RID: 49985
		private int opl_p3;
	}
}
