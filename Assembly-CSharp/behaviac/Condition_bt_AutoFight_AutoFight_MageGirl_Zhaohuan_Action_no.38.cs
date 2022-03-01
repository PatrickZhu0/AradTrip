using System;

namespace behaviac
{
	// Token: 0x0200277B RID: 10107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node31 : Condition
	{
		// Token: 0x06013837 RID: 79927 RVA: 0x005D08EA File Offset: 0x005CECEA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node31()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013838 RID: 79928 RVA: 0x005D0920 File Offset: 0x005CED20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D297 RID: 53911
		private int opl_p0;

		// Token: 0x0400D298 RID: 53912
		private int opl_p1;

		// Token: 0x0400D299 RID: 53913
		private int opl_p2;

		// Token: 0x0400D29A RID: 53914
		private int opl_p3;
	}
}
