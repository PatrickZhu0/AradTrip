using System;

namespace behaviac
{
	// Token: 0x020026A6 RID: 9894
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node33 : Condition
	{
		// Token: 0x06013690 RID: 79504 RVA: 0x005C7457 File Offset: 0x005C5857
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node33()
		{
			this.opl_p0 = 2008;
		}

		// Token: 0x06013691 RID: 79505 RVA: 0x005C746C File Offset: 0x005C586C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0E4 RID: 53476
		private int opl_p0;
	}
}
