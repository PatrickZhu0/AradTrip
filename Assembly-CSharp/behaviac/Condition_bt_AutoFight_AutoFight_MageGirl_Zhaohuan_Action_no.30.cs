using System;

namespace behaviac
{
	// Token: 0x02002770 RID: 10096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node17 : Condition
	{
		// Token: 0x06013821 RID: 79905 RVA: 0x005D0449 File Offset: 0x005CE849
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013822 RID: 79906 RVA: 0x005D045C File Offset: 0x005CE85C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D283 RID: 53891
		private float opl_p0;
	}
}
