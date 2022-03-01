using System;

namespace behaviac
{
	// Token: 0x020029A4 RID: 10660
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node19 : Condition
	{
		// Token: 0x06013C7C RID: 81020 RVA: 0x005EA8A5 File Offset: 0x005E8CA5
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node19()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013C7D RID: 81021 RVA: 0x005EA8B8 File Offset: 0x005E8CB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6E9 RID: 55017
		private float opl_p0;
	}
}
