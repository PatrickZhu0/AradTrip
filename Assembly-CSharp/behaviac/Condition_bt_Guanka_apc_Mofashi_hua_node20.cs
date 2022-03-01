using System;

namespace behaviac
{
	// Token: 0x02002A8C RID: 10892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node20 : Condition
	{
		// Token: 0x06013E3C RID: 81468 RVA: 0x005F6D0B File Offset: 0x005F510B
		public Condition_bt_Guanka_apc_Mofashi_hua_node20()
		{
			this.opl_p0 = 2006;
		}

		// Token: 0x06013E3D RID: 81469 RVA: 0x005F6D20 File Offset: 0x005F5120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8B1 RID: 55473
		private int opl_p0;
	}
}
