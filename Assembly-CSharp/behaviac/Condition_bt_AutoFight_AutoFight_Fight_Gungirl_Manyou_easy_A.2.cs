using System;

namespace behaviac
{
	// Token: 0x02001FC0 RID: 8128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node3 : Condition
	{
		// Token: 0x0601291D RID: 76061 RVA: 0x00571233 File Offset: 0x0056F633
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601291E RID: 76062 RVA: 0x00571268 File Offset: 0x0056F668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C30E RID: 49934
		private int opl_p0;

		// Token: 0x0400C30F RID: 49935
		private int opl_p1;

		// Token: 0x0400C310 RID: 49936
		private int opl_p2;

		// Token: 0x0400C311 RID: 49937
		private int opl_p3;
	}
}
