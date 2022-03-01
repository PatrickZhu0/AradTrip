using System;

namespace behaviac
{
	// Token: 0x02002A88 RID: 10888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node14 : Condition
	{
		// Token: 0x06013E34 RID: 81460 RVA: 0x005F6B57 File Offset: 0x005F4F57
		public Condition_bt_Guanka_apc_Mofashi_hua_node14()
		{
			this.opl_p0 = 2011;
		}

		// Token: 0x06013E35 RID: 81461 RVA: 0x005F6B6C File Offset: 0x005F4F6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8A9 RID: 55465
		private int opl_p0;
	}
}
