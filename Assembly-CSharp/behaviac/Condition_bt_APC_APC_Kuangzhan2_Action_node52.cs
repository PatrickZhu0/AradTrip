using System;

namespace behaviac
{
	// Token: 0x02001D80 RID: 7552
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node52 : Condition
	{
		// Token: 0x060124BB RID: 74939 RVA: 0x00556B87 File Offset: 0x00554F87
		public Condition_bt_APC_APC_Kuangzhan2_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060124BC RID: 74940 RVA: 0x00556BA4 File Offset: 0x00554FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEA5 RID: 48805
		private BE_Target opl_p0;

		// Token: 0x0400BEA6 RID: 48806
		private BE_Equal opl_p1;

		// Token: 0x0400BEA7 RID: 48807
		private BE_State opl_p2;
	}
}
