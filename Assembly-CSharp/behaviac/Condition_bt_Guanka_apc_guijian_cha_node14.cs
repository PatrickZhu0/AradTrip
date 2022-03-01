using System;

namespace behaviac
{
	// Token: 0x02002A3D RID: 10813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node14 : Condition
	{
		// Token: 0x06013DA6 RID: 81318 RVA: 0x005F286F File Offset: 0x005F0C6F
		public Condition_bt_Guanka_apc_guijian_cha_node14()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013DA7 RID: 81319 RVA: 0x005F2884 File Offset: 0x005F0C84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D818 RID: 55320
		private int opl_p0;
	}
}
