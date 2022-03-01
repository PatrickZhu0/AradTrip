using System;

namespace behaviac
{
	// Token: 0x02002AC2 RID: 10946
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node7 : Condition
	{
		// Token: 0x06013EA0 RID: 81568 RVA: 0x005F97BF File Offset: 0x005F7BBF
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node7()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x06013EA1 RID: 81569 RVA: 0x005F97D4 File Offset: 0x005F7BD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D913 RID: 55571
		private int opl_p0;
	}
}
