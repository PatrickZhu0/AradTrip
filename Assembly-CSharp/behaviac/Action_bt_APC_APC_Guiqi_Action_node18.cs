using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D38 RID: 7480
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi_Action_node18 : Action
	{
		// Token: 0x06012432 RID: 74802 RVA: 0x005538E4 File Offset: 0x00551CE4
		public Action_bt_APC_APC_Guiqi_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 200;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 7098;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012433 RID: 74803 RVA: 0x00553978 File Offset: 0x00551D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE22 RID: 48674
		private List<Input> method_p0;

		// Token: 0x0400BE23 RID: 48675
		private bool method_p1;
	}
}
