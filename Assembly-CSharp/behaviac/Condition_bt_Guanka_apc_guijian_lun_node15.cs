using System;

namespace behaviac
{
	// Token: 0x02002A68 RID: 10856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_lun_node15 : Condition
	{
		// Token: 0x06013DF8 RID: 81400 RVA: 0x005F4E0B File Offset: 0x005F320B
		public Condition_bt_Guanka_apc_guijian_lun_node15()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013DF9 RID: 81401 RVA: 0x005F4E20 File Offset: 0x005F3220
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D86B RID: 55403
		private int opl_p0;
	}
}
