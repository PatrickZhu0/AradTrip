using System;

namespace behaviac
{
	// Token: 0x02001F89 RID: 8073
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node19 : Condition
	{
		// Token: 0x060128B2 RID: 75954 RVA: 0x0056E2D5 File Offset: 0x0056C6D5
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node19()
		{
			this.opl_p0 = 2507;
		}

		// Token: 0x060128B3 RID: 75955 RVA: 0x0056E2E8 File Offset: 0x0056C6E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A5 RID: 49829
		private int opl_p0;
	}
}
