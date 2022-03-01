using System;

namespace behaviac
{
	// Token: 0x020029A7 RID: 10663
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node35 : Condition
	{
		// Token: 0x06013C82 RID: 81026 RVA: 0x005EA9DE File Offset: 0x005E8DDE
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node35()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C83 RID: 81027 RVA: 0x005EA9F4 File Offset: 0x005E8DF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6ED RID: 55021
		private float opl_p0;
	}
}
