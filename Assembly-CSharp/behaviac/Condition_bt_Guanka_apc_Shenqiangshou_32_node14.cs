using System;

namespace behaviac
{
	// Token: 0x02002AB7 RID: 10935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node14 : Condition
	{
		// Token: 0x06013E8C RID: 81548 RVA: 0x005F8E77 File Offset: 0x005F7277
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node14()
		{
			this.opl_p0 = 1008;
		}

		// Token: 0x06013E8D RID: 81549 RVA: 0x005F8E8C File Offset: 0x005F728C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D900 RID: 55552
		private int opl_p0;
	}
}
