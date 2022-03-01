using System;

namespace behaviac
{
	// Token: 0x020029B2 RID: 10674
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node104 : Condition
	{
		// Token: 0x06013C98 RID: 81048 RVA: 0x005EAE69 File Offset: 0x005E9269
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node104()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013C99 RID: 81049 RVA: 0x005EAE88 File Offset: 0x005E9288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D705 RID: 55045
		private BE_Target opl_p0;

		// Token: 0x0400D706 RID: 55046
		private BE_Equal opl_p1;

		// Token: 0x0400D707 RID: 55047
		private BE_State opl_p2;
	}
}
