using System;

namespace behaviac
{
	// Token: 0x020026BB RID: 9915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node3 : Condition
	{
		// Token: 0x060136B9 RID: 79545 RVA: 0x005C8AE1 File Offset: 0x005C6EE1
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node3()
		{
			this.opl_p0 = 2111;
		}

		// Token: 0x060136BA RID: 79546 RVA: 0x005C8AF4 File Offset: 0x005C6EF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D110 RID: 53520
		private int opl_p0;
	}
}
