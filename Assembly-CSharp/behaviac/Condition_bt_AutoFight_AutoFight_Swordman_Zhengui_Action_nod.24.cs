using System;

namespace behaviac
{
	// Token: 0x0200299B RID: 10651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node123 : Condition
	{
		// Token: 0x06013C6A RID: 81002 RVA: 0x005EA509 File Offset: 0x005E8909
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node123()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013C6B RID: 81003 RVA: 0x005EA51C File Offset: 0x005E891C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6D7 RID: 54999
		private float opl_p0;
	}
}
