using System;

namespace behaviac
{
	// Token: 0x02002A21 RID: 10785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Cimeiguifeiyan_node4 : Condition
	{
		// Token: 0x06013D70 RID: 81264 RVA: 0x005F1069 File Offset: 0x005EF469
		public Condition_bt_Guanka_apc_Cimeiguifeiyan_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D71 RID: 81265 RVA: 0x005F1088 File Offset: 0x005EF488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7DE RID: 55262
		private BE_Target opl_p0;

		// Token: 0x0400D7DF RID: 55263
		private BE_Equal opl_p1;

		// Token: 0x0400D7E0 RID: 55264
		private BE_State opl_p2;
	}
}
