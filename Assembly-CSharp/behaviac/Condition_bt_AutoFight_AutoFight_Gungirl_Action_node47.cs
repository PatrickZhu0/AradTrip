using System;

namespace behaviac
{
	// Token: 0x020024C2 RID: 9410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node47 : Condition
	{
		// Token: 0x060132CF RID: 78543 RVA: 0x005B0FA9 File Offset: 0x005AF3A9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node47()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060132D0 RID: 78544 RVA: 0x005B0FC8 File Offset: 0x005AF3C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCEB RID: 52459
		private BE_Target opl_p0;

		// Token: 0x0400CCEC RID: 52460
		private BE_Equal opl_p1;

		// Token: 0x0400CCED RID: 52461
		private BE_State opl_p2;
	}
}
