using System;

namespace behaviac
{
	// Token: 0x0200269A RID: 9882
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node23 : Condition
	{
		// Token: 0x06013678 RID: 79480 RVA: 0x005C6F3B File Offset: 0x005C533B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node23()
		{
			this.opl_p0 = 2011;
		}

		// Token: 0x06013679 RID: 79481 RVA: 0x005C6F50 File Offset: 0x005C5350
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0CC RID: 53452
		private int opl_p0;
	}
}
