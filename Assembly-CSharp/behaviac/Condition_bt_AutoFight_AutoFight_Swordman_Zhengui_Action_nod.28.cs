using System;

namespace behaviac
{
	// Token: 0x020029A1 RID: 10657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node74 : Condition
	{
		// Token: 0x06013C76 RID: 81014 RVA: 0x005EA73B File Offset: 0x005E8B3B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node74()
		{
			this.opl_p0 = 1806;
		}

		// Token: 0x06013C77 RID: 81015 RVA: 0x005EA750 File Offset: 0x005E8B50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6E2 RID: 55010
		private int opl_p0;
	}
}
