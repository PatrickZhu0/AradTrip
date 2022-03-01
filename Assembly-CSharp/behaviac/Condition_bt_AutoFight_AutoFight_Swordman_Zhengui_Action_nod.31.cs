using System;

namespace behaviac
{
	// Token: 0x020029A5 RID: 10661
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node21 : Condition
	{
		// Token: 0x06013C7E RID: 81022 RVA: 0x005EA8EB File Offset: 0x005E8CEB
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node21()
		{
			this.opl_p0 = 1521;
		}

		// Token: 0x06013C7F RID: 81023 RVA: 0x005EA900 File Offset: 0x005E8D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6EA RID: 55018
		private int opl_p0;
	}
}
