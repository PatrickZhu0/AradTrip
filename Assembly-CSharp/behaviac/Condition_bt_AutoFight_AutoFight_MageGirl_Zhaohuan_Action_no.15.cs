using System;

namespace behaviac
{
	// Token: 0x0200275C RID: 10076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node65 : Condition
	{
		// Token: 0x060137F9 RID: 79865 RVA: 0x005CFB92 File Offset: 0x005CDF92
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node65()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137FA RID: 79866 RVA: 0x005CFBC8 File Offset: 0x005CDFC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D258 RID: 53848
		private int opl_p0;

		// Token: 0x0400D259 RID: 53849
		private int opl_p1;

		// Token: 0x0400D25A RID: 53850
		private int opl_p2;

		// Token: 0x0400D25B RID: 53851
		private int opl_p3;
	}
}
