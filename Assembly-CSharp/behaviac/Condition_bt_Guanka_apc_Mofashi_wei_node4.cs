using System;

namespace behaviac
{
	// Token: 0x02002AA3 RID: 10915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node4 : Condition
	{
		// Token: 0x06013E66 RID: 81510 RVA: 0x005F8090 File Offset: 0x005F6490
		public Condition_bt_Guanka_apc_Mofashi_wei_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E67 RID: 81511 RVA: 0x005F80B0 File Offset: 0x005F64B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8DA RID: 55514
		private BE_Target opl_p0;

		// Token: 0x0400D8DB RID: 55515
		private BE_Equal opl_p1;

		// Token: 0x0400D8DC RID: 55516
		private BE_State opl_p2;
	}
}
