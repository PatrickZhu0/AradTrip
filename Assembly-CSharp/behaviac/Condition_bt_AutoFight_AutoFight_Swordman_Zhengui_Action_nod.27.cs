using System;

namespace behaviac
{
	// Token: 0x020029A0 RID: 10656
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node73 : Condition
	{
		// Token: 0x06013C74 RID: 81012 RVA: 0x005EA6F5 File Offset: 0x005E8AF5
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node73()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013C75 RID: 81013 RVA: 0x005EA708 File Offset: 0x005E8B08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6E1 RID: 55009
		private float opl_p0;
	}
}
