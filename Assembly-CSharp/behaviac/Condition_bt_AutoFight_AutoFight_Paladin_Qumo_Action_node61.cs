using System;

namespace behaviac
{
	// Token: 0x020027E3 RID: 10211
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node61 : Condition
	{
		// Token: 0x06013905 RID: 80133 RVA: 0x005D54B6 File Offset: 0x005D38B6
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node61()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013906 RID: 80134 RVA: 0x005D54EC File Offset: 0x005D38EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D363 RID: 54115
		private int opl_p0;

		// Token: 0x0400D364 RID: 54116
		private int opl_p1;

		// Token: 0x0400D365 RID: 54117
		private int opl_p2;

		// Token: 0x0400D366 RID: 54118
		private int opl_p3;
	}
}
