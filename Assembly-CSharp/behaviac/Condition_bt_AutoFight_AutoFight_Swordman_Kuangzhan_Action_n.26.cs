using System;

namespace behaviac
{
	// Token: 0x02002965 RID: 10597
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node54 : Condition
	{
		// Token: 0x06013BFF RID: 80895 RVA: 0x005E798D File Offset: 0x005E5D8D
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node54()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013C00 RID: 80896 RVA: 0x005E79A0 File Offset: 0x005E5DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D666 RID: 54886
		private float opl_p0;
	}
}
