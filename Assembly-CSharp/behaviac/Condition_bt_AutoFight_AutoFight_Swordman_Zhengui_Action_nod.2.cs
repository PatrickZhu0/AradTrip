using System;

namespace behaviac
{
	// Token: 0x0200297F RID: 10623
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node0 : Condition
	{
		// Token: 0x06013C32 RID: 80946 RVA: 0x005E9733 File Offset: 0x005E7B33
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node0()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013C33 RID: 80947 RVA: 0x005E9748 File Offset: 0x005E7B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D69B RID: 54939
		private float opl_p0;
	}
}
