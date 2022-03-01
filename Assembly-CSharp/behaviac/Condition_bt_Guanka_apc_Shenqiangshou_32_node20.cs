using System;

namespace behaviac
{
	// Token: 0x02002ABB RID: 10939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node20 : Condition
	{
		// Token: 0x06013E94 RID: 81556 RVA: 0x005F9087 File Offset: 0x005F7487
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node20()
		{
			this.opl_p0 = 1012;
		}

		// Token: 0x06013E95 RID: 81557 RVA: 0x005F909C File Offset: 0x005F749C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D908 RID: 55560
		private int opl_p0;
	}
}
