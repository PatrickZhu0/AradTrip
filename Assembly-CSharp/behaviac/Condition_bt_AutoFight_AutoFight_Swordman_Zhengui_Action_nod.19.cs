using System;

namespace behaviac
{
	// Token: 0x02002995 RID: 10645
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node23 : Condition
	{
		// Token: 0x06013C5E RID: 80990 RVA: 0x005EA21E File Offset: 0x005E861E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013C5F RID: 80991 RVA: 0x005EA254 File Offset: 0x005E8654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6C8 RID: 54984
		private int opl_p0;

		// Token: 0x0400D6C9 RID: 54985
		private int opl_p1;

		// Token: 0x0400D6CA RID: 54986
		private int opl_p2;

		// Token: 0x0400D6CB RID: 54987
		private int opl_p3;
	}
}
