using System;

namespace behaviac
{
	// Token: 0x02002AB3 RID: 10931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node7 : Condition
	{
		// Token: 0x06013E84 RID: 81540 RVA: 0x005F8B53 File Offset: 0x005F6F53
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node7()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x06013E85 RID: 81541 RVA: 0x005F8B68 File Offset: 0x005F6F68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8F8 RID: 55544
		private int opl_p0;
	}
}
