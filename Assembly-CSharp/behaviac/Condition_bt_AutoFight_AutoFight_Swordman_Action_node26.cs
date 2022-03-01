using System;

namespace behaviac
{
	// Token: 0x02002878 RID: 10360
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node26 : Condition
	{
		// Token: 0x06013A2D RID: 80429 RVA: 0x005DCB02 File Offset: 0x005DAF02
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node26()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013A2E RID: 80430 RVA: 0x005DCB18 File Offset: 0x005DAF18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D486 RID: 54406
		private float opl_p0;
	}
}
