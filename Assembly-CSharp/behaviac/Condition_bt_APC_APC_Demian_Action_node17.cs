using System;

namespace behaviac
{
	// Token: 0x02001D07 RID: 7431
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node17 : Condition
	{
		// Token: 0x060123D3 RID: 74707 RVA: 0x00550E9B File Offset: 0x0054F29B
		public Condition_bt_APC_APC_Demian_Action_node17()
		{
			this.opl_p0 = 8006;
		}

		// Token: 0x060123D4 RID: 74708 RVA: 0x00550EB0 File Offset: 0x0054F2B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDCC RID: 48588
		private int opl_p0;
	}
}
