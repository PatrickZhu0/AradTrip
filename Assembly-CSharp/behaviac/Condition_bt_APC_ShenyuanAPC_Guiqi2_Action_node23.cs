using System;

namespace behaviac
{
	// Token: 0x02001E46 RID: 7750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node23 : Condition
	{
		// Token: 0x06012639 RID: 75321 RVA: 0x0055FB43 File Offset: 0x0055DF43
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node23()
		{
			this.opl_p0 = 9724;
		}

		// Token: 0x0601263A RID: 75322 RVA: 0x0055FB58 File Offset: 0x0055DF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C020 RID: 49184
		private int opl_p0;
	}
}
