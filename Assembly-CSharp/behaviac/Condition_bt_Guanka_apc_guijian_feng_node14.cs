using System;

namespace behaviac
{
	// Token: 0x02002A4B RID: 10827
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node14 : Condition
	{
		// Token: 0x06013DC1 RID: 81345 RVA: 0x005F353B File Offset: 0x005F193B
		public Condition_bt_Guanka_apc_guijian_feng_node14()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013DC2 RID: 81346 RVA: 0x005F3550 File Offset: 0x005F1950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D835 RID: 55349
		private int opl_p0;
	}
}
