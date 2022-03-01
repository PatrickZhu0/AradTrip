using System;

namespace behaviac
{
	// Token: 0x02002780 RID: 10112
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node37 : Condition
	{
		// Token: 0x06013841 RID: 79937 RVA: 0x005D0B19 File Offset: 0x005CEF19
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node37()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013842 RID: 79938 RVA: 0x005D0B2C File Offset: 0x005CEF2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2A3 RID: 53923
		private float opl_p0;
	}
}
