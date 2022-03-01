using System;

namespace behaviac
{
	// Token: 0x02002AC0 RID: 10944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node4 : Condition
	{
		// Token: 0x06013E9C RID: 81564 RVA: 0x005F9718 File Offset: 0x005F7B18
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E9D RID: 81565 RVA: 0x005F9738 File Offset: 0x005F7B38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D90F RID: 55567
		private BE_Target opl_p0;

		// Token: 0x0400D910 RID: 55568
		private BE_Equal opl_p1;

		// Token: 0x0400D911 RID: 55569
		private BE_State opl_p2;
	}
}
