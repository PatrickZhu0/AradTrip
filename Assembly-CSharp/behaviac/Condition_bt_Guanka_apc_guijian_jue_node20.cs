using System;

namespace behaviac
{
	// Token: 0x02002A61 RID: 10849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node20 : Condition
	{
		// Token: 0x06013DEC RID: 81388 RVA: 0x005F4713 File Offset: 0x005F2B13
		public Condition_bt_Guanka_apc_guijian_jue_node20()
		{
			this.opl_p0 = 1608;
		}

		// Token: 0x06013DED RID: 81389 RVA: 0x005F4728 File Offset: 0x005F2B28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D860 RID: 55392
		private int opl_p0;
	}
}
