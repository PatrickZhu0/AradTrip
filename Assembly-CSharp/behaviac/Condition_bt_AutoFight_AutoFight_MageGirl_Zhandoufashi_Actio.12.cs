using System;

namespace behaviac
{
	// Token: 0x0200270F RID: 9999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node99 : Condition
	{
		// Token: 0x06013760 RID: 79712 RVA: 0x005CC58B File Offset: 0x005CA98B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node99()
		{
			this.opl_p0 = 2307;
		}

		// Token: 0x06013761 RID: 79713 RVA: 0x005CC5A0 File Offset: 0x005CA9A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1B9 RID: 53689
		private int opl_p0;
	}
}
