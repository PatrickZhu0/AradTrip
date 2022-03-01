using System;

namespace behaviac
{
	// Token: 0x0200237E RID: 9086
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node39 : Condition
	{
		// Token: 0x06013063 RID: 77923 RVA: 0x005A0CB1 File Offset: 0x0059F0B1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node39()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013064 RID: 77924 RVA: 0x005A0CD0 File Offset: 0x0059F0D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA78 RID: 51832
		private BE_Target opl_p0;

		// Token: 0x0400CA79 RID: 51833
		private BE_Equal opl_p1;

		// Token: 0x0400CA7A RID: 51834
		private BE_State opl_p2;
	}
}
