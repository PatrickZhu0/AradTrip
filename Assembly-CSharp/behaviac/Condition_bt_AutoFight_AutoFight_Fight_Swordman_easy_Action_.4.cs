using System;

namespace behaviac
{
	// Token: 0x02002268 RID: 8808
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node10 : Condition
	{
		// Token: 0x06012E56 RID: 77398 RVA: 0x0059298B File Offset: 0x00590D8B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node10()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012E57 RID: 77399 RVA: 0x005929A0 File Offset: 0x00590DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C864 RID: 51300
		private int opl_p0;
	}
}
