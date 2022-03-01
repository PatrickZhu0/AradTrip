using System;

namespace behaviac
{
	// Token: 0x02002A18 RID: 10776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node12 : Condition
	{
		// Token: 0x06013D5F RID: 81247 RVA: 0x005F0891 File Offset: 0x005EEC91
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013D60 RID: 81248 RVA: 0x005F08B0 File Offset: 0x005EECB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7CC RID: 55244
		private BE_Target opl_p0;

		// Token: 0x0400D7CD RID: 55245
		private BE_Equal opl_p1;

		// Token: 0x0400D7CE RID: 55246
		private BE_State opl_p2;
	}
}
