using System;

namespace behaviac
{
	// Token: 0x02002985 RID: 10629
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node13 : Condition
	{
		// Token: 0x06013C3E RID: 80958 RVA: 0x005E998B File Offset: 0x005E7D8B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013C3F RID: 80959 RVA: 0x005E99A0 File Offset: 0x005E7DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6A7 RID: 54951
		private int opl_p0;
	}
}
