using System;

namespace behaviac
{
	// Token: 0x02002404 RID: 9220
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node56 : Condition
	{
		// Token: 0x06013167 RID: 78183 RVA: 0x005A85D9 File Offset: 0x005A69D9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node56()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013168 RID: 78184 RVA: 0x005A85F8 File Offset: 0x005A69F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB93 RID: 52115
		private BE_Target opl_p0;

		// Token: 0x0400CB94 RID: 52116
		private BE_Equal opl_p1;

		// Token: 0x0400CB95 RID: 52117
		private BE_State opl_p2;
	}
}
