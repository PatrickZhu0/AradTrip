using System;

namespace behaviac
{
	// Token: 0x0200238C RID: 9100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node56 : Condition
	{
		// Token: 0x0601307F RID: 77951 RVA: 0x005A12E9 File Offset: 0x0059F6E9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013080 RID: 77952 RVA: 0x005A1308 File Offset: 0x0059F708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA96 RID: 51862
		private BE_Target opl_p0;

		// Token: 0x0400CA97 RID: 51863
		private BE_Equal opl_p1;

		// Token: 0x0400CA98 RID: 51864
		private BE_State opl_p2;
	}
}
