using System;

namespace behaviac
{
	// Token: 0x02002705 RID: 9989
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node11 : Condition
	{
		// Token: 0x0601374C RID: 79692 RVA: 0x005CC17B File Offset: 0x005CA57B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node11()
		{
			this.opl_p0 = 2113;
		}

		// Token: 0x0601374D RID: 79693 RVA: 0x005CC190 File Offset: 0x005CA590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1A4 RID: 53668
		private int opl_p0;
	}
}
