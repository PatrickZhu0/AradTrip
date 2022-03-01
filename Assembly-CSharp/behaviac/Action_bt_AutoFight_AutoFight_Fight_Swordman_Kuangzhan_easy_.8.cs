using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002329 RID: 9001
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node51 : Action
	{
		// Token: 0x06012FC5 RID: 77765 RVA: 0x0059CBE4 File Offset: 0x0059AFE4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node51()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 1604;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012FC6 RID: 77766 RVA: 0x0059CC74 File Offset: 0x0059B074
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9DD RID: 51677
		private List<Input> method_p0;

		// Token: 0x0400C9DE RID: 51678
		private bool method_p1;
	}
}
