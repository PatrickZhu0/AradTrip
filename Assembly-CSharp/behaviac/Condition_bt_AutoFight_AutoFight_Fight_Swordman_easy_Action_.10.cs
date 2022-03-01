using System;

namespace behaviac
{
	// Token: 0x02002272 RID: 8818
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node21 : Condition
	{
		// Token: 0x06012E68 RID: 77416 RVA: 0x00592E1F File Offset: 0x0059121F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_easy_Action_node21()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012E69 RID: 77417 RVA: 0x00592E34 File Offset: 0x00591234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C874 RID: 51316
		private int opl_p0;
	}
}
