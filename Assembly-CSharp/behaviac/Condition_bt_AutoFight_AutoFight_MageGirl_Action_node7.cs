using System;

namespace behaviac
{
	// Token: 0x02002686 RID: 9862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node7 : Condition
	{
		// Token: 0x06013650 RID: 79440 RVA: 0x005C66B7 File Offset: 0x005C4AB7
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node7()
		{
			this.opl_p0 = 2007;
		}

		// Token: 0x06013651 RID: 79441 RVA: 0x005C66CC File Offset: 0x005C4ACC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0A4 RID: 53412
		private int opl_p0;
	}
}
