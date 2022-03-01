using System;

namespace behaviac
{
	// Token: 0x02001E53 RID: 7763
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node56 : Condition
	{
		// Token: 0x06012653 RID: 75347 RVA: 0x0056039F File Offset: 0x0055E79F
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node56()
		{
			this.opl_p0 = 9734;
		}

		// Token: 0x06012654 RID: 75348 RVA: 0x005603B4 File Offset: 0x0055E7B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C03B RID: 49211
		private int opl_p0;
	}
}
