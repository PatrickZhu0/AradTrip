using System;

namespace behaviac
{
	// Token: 0x0200299C RID: 10652
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node126 : Condition
	{
		// Token: 0x06013C6C RID: 81004 RVA: 0x005EA54F File Offset: 0x005E894F
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node126()
		{
			this.opl_p0 = 1812;
		}

		// Token: 0x06013C6D RID: 81005 RVA: 0x005EA564 File Offset: 0x005E8964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6D8 RID: 55000
		private int opl_p0;
	}
}
