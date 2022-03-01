using System;

namespace behaviac
{
	// Token: 0x020029CD RID: 10701
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node56 : Condition
	{
		// Token: 0x06013CCE RID: 81102 RVA: 0x005EBA79 File Offset: 0x005E9E79
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node56()
		{
			this.opl_p0 = 1818;
		}

		// Token: 0x06013CCF RID: 81103 RVA: 0x005EBA8C File Offset: 0x005E9E8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D73E RID: 55102
		private int opl_p0;
	}
}
