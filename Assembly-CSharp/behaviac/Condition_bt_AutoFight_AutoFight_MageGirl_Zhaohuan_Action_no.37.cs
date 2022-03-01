using System;

namespace behaviac
{
	// Token: 0x02002779 RID: 10105
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node23 : Condition
	{
		// Token: 0x06013833 RID: 79923 RVA: 0x005D07F7 File Offset: 0x005CEBF7
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node23()
		{
			this.opl_p0 = 2011;
		}

		// Token: 0x06013834 RID: 79924 RVA: 0x005D080C File Offset: 0x005CEC0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D294 RID: 53908
		private int opl_p0;
	}
}
