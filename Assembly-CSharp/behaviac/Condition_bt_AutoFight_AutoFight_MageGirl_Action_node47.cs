using System;

namespace behaviac
{
	// Token: 0x0200269E RID: 9886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node47 : Condition
	{
		// Token: 0x06013680 RID: 79488 RVA: 0x005C70EF File Offset: 0x005C54EF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node47()
		{
			this.opl_p0 = 2207;
		}

		// Token: 0x06013681 RID: 79489 RVA: 0x005C7104 File Offset: 0x005C5504
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0D4 RID: 53460
		private int opl_p0;
	}
}
