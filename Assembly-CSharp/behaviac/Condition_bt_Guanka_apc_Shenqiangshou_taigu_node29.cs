using System;

namespace behaviac
{
	// Token: 0x02002AC8 RID: 10952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node29 : Condition
	{
		// Token: 0x06013EAB RID: 81579 RVA: 0x005F9B53 File Offset: 0x005F7F53
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node29()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x06013EAC RID: 81580 RVA: 0x005F9B68 File Offset: 0x005F7F68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D91E RID: 55582
		private int opl_p0;
	}
}
