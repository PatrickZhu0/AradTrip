using System;

namespace behaviac
{
	// Token: 0x02002A2E RID: 10798
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node4 : Condition
	{
		// Token: 0x06013D89 RID: 81289 RVA: 0x005F1D19 File Offset: 0x005F0119
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D8A RID: 81290 RVA: 0x005F1D38 File Offset: 0x005F0138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7F8 RID: 55288
		private BE_Target opl_p0;

		// Token: 0x0400D7F9 RID: 55289
		private BE_Equal opl_p1;

		// Token: 0x0400D7FA RID: 55290
		private BE_State opl_p2;
	}
}
