using System;

namespace behaviac
{
	// Token: 0x0200268E RID: 9870
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node18 : Condition
	{
		// Token: 0x06013660 RID: 79456 RVA: 0x005C6A1F File Offset: 0x005C4E1F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node18()
		{
			this.opl_p0 = 2005;
		}

		// Token: 0x06013661 RID: 79457 RVA: 0x005C6A34 File Offset: 0x005C4E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0B4 RID: 53428
		private int opl_p0;
	}
}
