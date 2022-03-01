using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D41 RID: 7489
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_Action_node5 : Action
	{
		// Token: 0x06012443 RID: 74819 RVA: 0x005541B4 File Offset: 0x005525B4
		public Action_bt_APC_APC_Gunman_test_Action_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 2;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 3;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			Input item2 = default(Input);
			item2.delay = 4000;
			item2.moveInSkillState = false;
			item2.moveKeepDistance = 0;
			item2.PKRobotComboCheck = false;
			item2.pressTime = 0;
			item2.randomChangeDirection = false;
			item2.skillID = 4;
			item2.specialChoice = 0;
			this.method_p0.Add(item2);
			this.method_p1 = false;
		}

		// Token: 0x06012444 RID: 74820 RVA: 0x00554298 File Offset: 0x00552698
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE35 RID: 48693
		private List<Input> method_p0;

		// Token: 0x0400BE36 RID: 48694
		private bool method_p1;
	}
}
