using System;

namespace behaviac
{
	// Token: 0x0200226D RID: 8813
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node15 : Condition
	{
		// Token: 0x06012E5F RID: 77407 RVA: 0x00592C5B File Offset: 0x0059105B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node15()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x06012E60 RID: 77408 RVA: 0x00592C70 File Offset: 0x00591070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C86C RID: 51308
		private int opl_p0;
	}
}
