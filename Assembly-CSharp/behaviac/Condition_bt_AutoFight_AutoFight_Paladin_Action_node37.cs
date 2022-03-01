using System;

namespace behaviac
{
	// Token: 0x020027AB RID: 10155
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node37 : Condition
	{
		// Token: 0x06013896 RID: 80022 RVA: 0x005D2F96 File Offset: 0x005D1396
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node37()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013897 RID: 80023 RVA: 0x005D2FCC File Offset: 0x005D13CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2F5 RID: 54005
		private int opl_p0;

		// Token: 0x0400D2F6 RID: 54006
		private int opl_p1;

		// Token: 0x0400D2F7 RID: 54007
		private int opl_p2;

		// Token: 0x0400D2F8 RID: 54008
		private int opl_p3;
	}
}
