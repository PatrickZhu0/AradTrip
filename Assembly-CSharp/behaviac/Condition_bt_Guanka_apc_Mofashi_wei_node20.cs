using System;

namespace behaviac
{
	// Token: 0x02002AAC RID: 10924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node20 : Condition
	{
		// Token: 0x06013E78 RID: 81528 RVA: 0x005F8457 File Offset: 0x005F6857
		public Condition_bt_Guanka_apc_Mofashi_wei_node20()
		{
			this.opl_p0 = 2006;
		}

		// Token: 0x06013E79 RID: 81529 RVA: 0x005F846C File Offset: 0x005F686C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8ED RID: 55533
		private int opl_p0;
	}
}
