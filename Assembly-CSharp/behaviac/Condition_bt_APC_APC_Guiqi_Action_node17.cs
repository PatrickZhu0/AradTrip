using System;

namespace behaviac
{
	// Token: 0x02001D37 RID: 7479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node17 : Condition
	{
		// Token: 0x06012430 RID: 74800 RVA: 0x0055389B File Offset: 0x00551C9B
		public Condition_bt_APC_APC_Guiqi_Action_node17()
		{
			this.opl_p0 = 7098;
		}

		// Token: 0x06012431 RID: 74801 RVA: 0x005538B0 File Offset: 0x00551CB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE21 RID: 48673
		private int opl_p0;
	}
}
