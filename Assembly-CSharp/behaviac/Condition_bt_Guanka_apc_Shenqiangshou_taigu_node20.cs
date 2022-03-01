using System;

namespace behaviac
{
	// Token: 0x02002ACC RID: 10956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node20 : Condition
	{
		// Token: 0x06013EB3 RID: 81587 RVA: 0x005F9E77 File Offset: 0x005F8277
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node20()
		{
			this.opl_p0 = 1010;
		}

		// Token: 0x06013EB4 RID: 81588 RVA: 0x005F9E8C File Offset: 0x005F828C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D926 RID: 55590
		private int opl_p0;
	}
}
