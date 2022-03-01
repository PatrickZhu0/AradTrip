using System;

namespace behaviac
{
	// Token: 0x02001FE4 RID: 8164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node48 : Condition
	{
		// Token: 0x06012965 RID: 76133 RVA: 0x0057231B File Offset: 0x0057071B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012966 RID: 76134 RVA: 0x00572350 File Offset: 0x00570750
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C356 RID: 50006
		private int opl_p0;

		// Token: 0x0400C357 RID: 50007
		private int opl_p1;

		// Token: 0x0400C358 RID: 50008
		private int opl_p2;

		// Token: 0x0400C359 RID: 50009
		private int opl_p3;
	}
}
