using System;

namespace behaviac
{
	// Token: 0x02002950 RID: 10576
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node34 : Condition
	{
		// Token: 0x06013BD5 RID: 80853 RVA: 0x005E701D File Offset: 0x005E541D
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node34()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013BD6 RID: 80854 RVA: 0x005E7030 File Offset: 0x005E5430
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D63C RID: 54844
		private float opl_p0;
	}
}
