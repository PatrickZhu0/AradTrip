using System;

namespace behaviac
{
	// Token: 0x02001D22 RID: 7458
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node56 : Condition
	{
		// Token: 0x06012407 RID: 74759 RVA: 0x00552155 File Offset: 0x00550555
		public Condition_bt_APC_APC_Guiqi2_Action_node56()
		{
			this.opl_p0 = 9734;
		}

		// Token: 0x06012408 RID: 74760 RVA: 0x00552168 File Offset: 0x00550568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDF7 RID: 48631
		private int opl_p0;
	}
}
