using System;

namespace behaviac
{
	// Token: 0x02002A5D RID: 10845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node14 : Condition
	{
		// Token: 0x06013DE4 RID: 81380 RVA: 0x005F455F File Offset: 0x005F295F
		public Condition_bt_Guanka_apc_guijian_jue_node14()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x06013DE5 RID: 81381 RVA: 0x005F4574 File Offset: 0x005F2974
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D858 RID: 55384
		private int opl_p0;
	}
}
