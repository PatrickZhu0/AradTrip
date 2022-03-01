using System;

namespace behaviac
{
	// Token: 0x02002947 RID: 10567
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node97 : Condition
	{
		// Token: 0x06013BC3 RID: 80835 RVA: 0x005E6C5D File Offset: 0x005E505D
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node97()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013BC4 RID: 80836 RVA: 0x005E6C70 File Offset: 0x005E5070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D629 RID: 54825
		private float opl_p0;
	}
}
