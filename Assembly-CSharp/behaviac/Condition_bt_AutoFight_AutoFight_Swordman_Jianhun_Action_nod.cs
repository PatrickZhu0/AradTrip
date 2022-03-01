using System;

namespace behaviac
{
	// Token: 0x02002905 RID: 10501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node24 : Condition
	{
		// Token: 0x06013B40 RID: 80704 RVA: 0x005E3923 File Offset: 0x005E1D23
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node24()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06013B41 RID: 80705 RVA: 0x005E3958 File Offset: 0x005E1D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5A2 RID: 54690
		private int opl_p0;

		// Token: 0x0400D5A3 RID: 54691
		private int opl_p1;

		// Token: 0x0400D5A4 RID: 54692
		private int opl_p2;

		// Token: 0x0400D5A5 RID: 54693
		private int opl_p3;
	}
}
