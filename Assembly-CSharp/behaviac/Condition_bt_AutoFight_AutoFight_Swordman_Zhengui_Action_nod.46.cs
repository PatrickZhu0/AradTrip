using System;

namespace behaviac
{
	// Token: 0x020029B9 RID: 10681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node37 : Condition
	{
		// Token: 0x06013CA6 RID: 81062 RVA: 0x005EB16E File Offset: 0x005E956E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node37()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013CA7 RID: 81063 RVA: 0x005EB184 File Offset: 0x005E9584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D713 RID: 55059
		private float opl_p0;
	}
}
