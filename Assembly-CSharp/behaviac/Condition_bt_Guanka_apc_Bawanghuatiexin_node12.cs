using System;

namespace behaviac
{
	// Token: 0x02002A0F RID: 10767
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node12 : Condition
	{
		// Token: 0x06013D4E RID: 81230 RVA: 0x005EFEE9 File Offset: 0x005EE2E9
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D4F RID: 81231 RVA: 0x005EFF08 File Offset: 0x005EE308
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7BA RID: 55226
		private BE_Target opl_p0;

		// Token: 0x0400D7BB RID: 55227
		private BE_Equal opl_p1;

		// Token: 0x0400D7BC RID: 55228
		private BE_State opl_p2;
	}
}
