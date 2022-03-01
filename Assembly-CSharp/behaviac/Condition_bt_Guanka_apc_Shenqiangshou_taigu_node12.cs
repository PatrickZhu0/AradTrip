using System;

namespace behaviac
{
	// Token: 0x02002AC6 RID: 10950
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node12 : Condition
	{
		// Token: 0x06013EA7 RID: 81575 RVA: 0x005F9AAC File Offset: 0x005F7EAC
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013EA8 RID: 81576 RVA: 0x005F9ACC File Offset: 0x005F7ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D91A RID: 55578
		private BE_Target opl_p0;

		// Token: 0x0400D91B RID: 55579
		private BE_Equal opl_p1;

		// Token: 0x0400D91C RID: 55580
		private BE_State opl_p2;
	}
}
