using System;

namespace behaviac
{
	// Token: 0x020029CB RID: 10699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node60 : Condition
	{
		// Token: 0x06013CCA RID: 81098 RVA: 0x005EB9B6 File Offset: 0x005E9DB6
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node60()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013CCB RID: 81099 RVA: 0x005EB9CC File Offset: 0x005E9DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D739 RID: 55097
		private float opl_p0;
	}
}
