using System;

namespace behaviac
{
	// Token: 0x020029D2 RID: 10706
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node66 : Condition
	{
		// Token: 0x06013CD8 RID: 81112 RVA: 0x005EBC8B File Offset: 0x005EA08B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node66()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013CD9 RID: 81113 RVA: 0x005EBCA0 File Offset: 0x005EA0A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D749 RID: 55113
		private int opl_p0;
	}
}
