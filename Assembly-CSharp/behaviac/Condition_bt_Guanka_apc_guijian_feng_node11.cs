using System;

namespace behaviac
{
	// Token: 0x02002A49 RID: 10825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node11 : Condition
	{
		// Token: 0x06013DBD RID: 81341 RVA: 0x005F3495 File Offset: 0x005F1895
		public Condition_bt_Guanka_apc_guijian_feng_node11()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013DBE RID: 81342 RVA: 0x005F34B4 File Offset: 0x005F18B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D831 RID: 55345
		private BE_Target opl_p0;

		// Token: 0x0400D832 RID: 55346
		private BE_Equal opl_p1;

		// Token: 0x0400D833 RID: 55347
		private BE_State opl_p2;
	}
}
