using System;

namespace behaviac
{
	// Token: 0x0200271A RID: 10010
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node35 : Condition
	{
		// Token: 0x06013776 RID: 79734 RVA: 0x005CCA5F File Offset: 0x005CAE5F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node35()
		{
			this.opl_p0 = 2304;
		}

		// Token: 0x06013777 RID: 79735 RVA: 0x005CCA74 File Offset: 0x005CAE74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1D0 RID: 53712
		private int opl_p0;
	}
}
