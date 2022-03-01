using System;

namespace behaviac
{
	// Token: 0x02002807 RID: 10247
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node96 : Condition
	{
		// Token: 0x0601394D RID: 80205 RVA: 0x005D640A File Offset: 0x005D480A
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node96()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601394E RID: 80206 RVA: 0x005D6440 File Offset: 0x005D4840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3AB RID: 54187
		private int opl_p0;

		// Token: 0x0400D3AC RID: 54188
		private int opl_p1;

		// Token: 0x0400D3AD RID: 54189
		private int opl_p2;

		// Token: 0x0400D3AE RID: 54190
		private int opl_p3;
	}
}
