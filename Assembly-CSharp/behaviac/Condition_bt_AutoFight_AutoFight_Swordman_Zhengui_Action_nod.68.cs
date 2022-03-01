using System;

namespace behaviac
{
	// Token: 0x020029D5 RID: 10709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node132 : Condition
	{
		// Token: 0x06013CDE RID: 81118 RVA: 0x005EBDDF File Offset: 0x005EA1DF
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node132()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013CDF RID: 81119 RVA: 0x005EBE14 File Offset: 0x005EA214
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D74F RID: 55119
		private int opl_p0;

		// Token: 0x0400D750 RID: 55120
		private int opl_p1;

		// Token: 0x0400D751 RID: 55121
		private int opl_p2;

		// Token: 0x0400D752 RID: 55122
		private int opl_p3;
	}
}
