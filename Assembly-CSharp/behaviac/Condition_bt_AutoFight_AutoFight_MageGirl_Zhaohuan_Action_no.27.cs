using System;

namespace behaviac
{
	// Token: 0x0200276C RID: 10092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node12 : Condition
	{
		// Token: 0x06013819 RID: 79897 RVA: 0x005D0295 File Offset: 0x005CE695
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601381A RID: 79898 RVA: 0x005D02A8 File Offset: 0x005CE6A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D27B RID: 53883
		private float opl_p0;
	}
}
