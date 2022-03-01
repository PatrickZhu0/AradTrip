using System;

namespace behaviac
{
	// Token: 0x02002980 RID: 10624
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node7 : Condition
	{
		// Token: 0x06013C34 RID: 80948 RVA: 0x005E977B File Offset: 0x005E7B7B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node7()
		{
			this.opl_p0 = 1800;
		}

		// Token: 0x06013C35 RID: 80949 RVA: 0x005E9790 File Offset: 0x005E7B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D69C RID: 54940
		private int opl_p0;
	}
}
