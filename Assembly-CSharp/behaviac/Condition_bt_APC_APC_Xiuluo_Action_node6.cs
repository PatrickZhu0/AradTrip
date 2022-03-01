using System;

namespace behaviac
{
	// Token: 0x02001E39 RID: 7737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node6 : Condition
	{
		// Token: 0x06012620 RID: 75296 RVA: 0x0055F03B File Offset: 0x0055D43B
		public Condition_bt_APC_APC_Xiuluo_Action_node6()
		{
			this.opl_p0 = 7097;
		}

		// Token: 0x06012621 RID: 75297 RVA: 0x0055F050 File Offset: 0x0055D450
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C008 RID: 49160
		private int opl_p0;
	}
}
