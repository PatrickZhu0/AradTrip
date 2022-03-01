using System;

namespace behaviac
{
	// Token: 0x02002AA8 RID: 10920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_wei_node14 : Condition
	{
		// Token: 0x06013E70 RID: 81520 RVA: 0x005F82A3 File Offset: 0x005F66A3
		public Condition_bt_Guanka_apc_Mofashi_wei_node14()
		{
			this.opl_p0 = 2003;
		}

		// Token: 0x06013E71 RID: 81521 RVA: 0x005F82B8 File Offset: 0x005F66B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8E5 RID: 55525
		private int opl_p0;
	}
}
