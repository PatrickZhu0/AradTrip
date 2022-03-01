using System;

namespace behaviac
{
	// Token: 0x02002A45 RID: 10821
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node4 : Condition
	{
		// Token: 0x06013DB5 RID: 81333 RVA: 0x005F3211 File Offset: 0x005F1611
		public Condition_bt_Guanka_apc_guijian_feng_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013DB6 RID: 81334 RVA: 0x005F3230 File Offset: 0x005F1630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D827 RID: 55335
		private BE_Target opl_p0;

		// Token: 0x0400D828 RID: 55336
		private BE_Equal opl_p1;

		// Token: 0x0400D829 RID: 55337
		private BE_State opl_p2;
	}
}
