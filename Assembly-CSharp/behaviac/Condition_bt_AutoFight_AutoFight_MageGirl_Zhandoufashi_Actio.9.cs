using System;

namespace behaviac
{
	// Token: 0x0200270B RID: 9995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node80 : Condition
	{
		// Token: 0x06013758 RID: 79704 RVA: 0x005CC3EF File Offset: 0x005CA7EF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node80()
		{
			this.opl_p0 = 2327;
		}

		// Token: 0x06013759 RID: 79705 RVA: 0x005CC404 File Offset: 0x005CA804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1B2 RID: 53682
		private int opl_p0;
	}
}
