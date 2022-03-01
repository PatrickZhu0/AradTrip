using System;

namespace behaviac
{
	// Token: 0x02001FE0 RID: 8160
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node43 : Condition
	{
		// Token: 0x0601295D RID: 76125 RVA: 0x0057217F File Offset: 0x0057057F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601295E RID: 76126 RVA: 0x005721B4 File Offset: 0x005705B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C34E RID: 49998
		private int opl_p0;

		// Token: 0x0400C34F RID: 49999
		private int opl_p1;

		// Token: 0x0400C350 RID: 50000
		private int opl_p2;

		// Token: 0x0400C351 RID: 50001
		private int opl_p3;
	}
}
