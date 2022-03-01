using System;

namespace behaviac
{
	// Token: 0x0200206F RID: 8303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node18 : Condition
	{
		// Token: 0x06012A77 RID: 76407 RVA: 0x005792D7 File Offset: 0x005776D7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A78 RID: 76408 RVA: 0x0057930C File Offset: 0x0057770C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C469 RID: 50281
		private int opl_p0;

		// Token: 0x0400C46A RID: 50282
		private int opl_p1;

		// Token: 0x0400C46B RID: 50283
		private int opl_p2;

		// Token: 0x0400C46C RID: 50284
		private int opl_p3;
	}
}
