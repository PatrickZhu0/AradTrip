using System;

namespace behaviac
{
	// Token: 0x020029DA RID: 10714
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node81 : Condition
	{
		// Token: 0x06013CE8 RID: 81128 RVA: 0x005EBFDB File Offset: 0x005EA3DB
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node81()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013CE9 RID: 81129 RVA: 0x005EC010 File Offset: 0x005EA410
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D758 RID: 55128
		private int opl_p0;

		// Token: 0x0400D759 RID: 55129
		private int opl_p1;

		// Token: 0x0400D75A RID: 55130
		private int opl_p2;

		// Token: 0x0400D75B RID: 55131
		private int opl_p3;
	}
}
