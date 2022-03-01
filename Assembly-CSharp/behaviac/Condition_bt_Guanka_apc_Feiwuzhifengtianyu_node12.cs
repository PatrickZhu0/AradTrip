using System;

namespace behaviac
{
	// Token: 0x02002A33 RID: 10803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node12 : Condition
	{
		// Token: 0x06013D93 RID: 81299 RVA: 0x005F203F File Offset: 0x005F043F
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node12()
		{
			this.opl_p0 = 2510;
		}

		// Token: 0x06013D94 RID: 81300 RVA: 0x005F2054 File Offset: 0x005F0454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D803 RID: 55299
		private int opl_p0;
	}
}
