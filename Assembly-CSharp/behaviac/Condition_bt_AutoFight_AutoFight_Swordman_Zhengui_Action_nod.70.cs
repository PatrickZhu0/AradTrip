using System;

namespace behaviac
{
	// Token: 0x020029D7 RID: 10711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node134 : Condition
	{
		// Token: 0x06013CE2 RID: 81122 RVA: 0x005EBE9F File Offset: 0x005EA29F
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node134()
		{
			this.opl_p0 = 1819;
		}

		// Token: 0x06013CE3 RID: 81123 RVA: 0x005EBEB4 File Offset: 0x005EA2B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D754 RID: 55124
		private int opl_p0;
	}
}
