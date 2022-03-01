using System;

namespace behaviac
{
	// Token: 0x020029A9 RID: 10665
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node88 : Condition
	{
		// Token: 0x06013C86 RID: 81030 RVA: 0x005EAAA1 File Offset: 0x005E8EA1
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node88()
		{
			this.opl_p0 = 1807;
		}

		// Token: 0x06013C87 RID: 81031 RVA: 0x005EAAB4 File Offset: 0x005E8EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6F2 RID: 55026
		private int opl_p0;
	}
}
