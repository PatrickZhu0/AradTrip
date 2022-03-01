using System;

namespace behaviac
{
	// Token: 0x02002AB1 RID: 10929
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node4 : Condition
	{
		// Token: 0x06013E80 RID: 81536 RVA: 0x005F8AAC File Offset: 0x005F6EAC
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013E81 RID: 81537 RVA: 0x005F8ACC File Offset: 0x005F6ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8F4 RID: 55540
		private BE_Target opl_p0;

		// Token: 0x0400D8F5 RID: 55541
		private BE_Equal opl_p1;

		// Token: 0x0400D8F6 RID: 55542
		private BE_State opl_p2;
	}
}
