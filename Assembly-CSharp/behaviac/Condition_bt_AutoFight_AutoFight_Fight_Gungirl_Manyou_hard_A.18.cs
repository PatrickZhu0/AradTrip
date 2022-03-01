using System;

namespace behaviac
{
	// Token: 0x02002033 RID: 8243
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node43 : Condition
	{
		// Token: 0x06012A01 RID: 76289 RVA: 0x00576067 File Offset: 0x00574467
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A02 RID: 76290 RVA: 0x0057609C File Offset: 0x0057449C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3F3 RID: 50163
		private int opl_p0;

		// Token: 0x0400C3F4 RID: 50164
		private int opl_p1;

		// Token: 0x0400C3F5 RID: 50165
		private int opl_p2;

		// Token: 0x0400C3F6 RID: 50166
		private int opl_p3;
	}
}
