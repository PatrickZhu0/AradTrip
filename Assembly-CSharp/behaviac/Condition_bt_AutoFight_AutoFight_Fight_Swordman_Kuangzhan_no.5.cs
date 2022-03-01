using System;

namespace behaviac
{
	// Token: 0x020023E2 RID: 9186
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node12 : Condition
	{
		// Token: 0x06013126 RID: 78118 RVA: 0x005A76DF File Offset: 0x005A5ADF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013127 RID: 78119 RVA: 0x005A76FC File Offset: 0x005A5AFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB52 RID: 52050
		private BE_Target opl_p0;

		// Token: 0x0400CB53 RID: 52051
		private BE_Equal opl_p1;

		// Token: 0x0400CB54 RID: 52052
		private BE_State opl_p2;
	}
}
