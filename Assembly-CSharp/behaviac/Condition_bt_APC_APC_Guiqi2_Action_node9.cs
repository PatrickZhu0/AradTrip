using System;

namespace behaviac
{
	// Token: 0x02001D29 RID: 7465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node9 : Condition
	{
		// Token: 0x06012415 RID: 74773 RVA: 0x00552475 File Offset: 0x00550875
		public Condition_bt_APC_APC_Guiqi2_Action_node9()
		{
			this.opl_p0 = 9728;
		}

		// Token: 0x06012416 RID: 74774 RVA: 0x00552488 File Offset: 0x00550888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE06 RID: 48646
		private int opl_p0;
	}
}
