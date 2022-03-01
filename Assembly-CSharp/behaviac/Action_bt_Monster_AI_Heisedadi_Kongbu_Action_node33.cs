using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034A8 RID: 13480
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node33 : Action
	{
		// Token: 0x06015198 RID: 86424 RVA: 0x0065BA28 File Offset: 0x00659E28
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node33()
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
			item.skillID = 6203;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015199 RID: 86425 RVA: 0x0065BAB8 File Offset: 0x00659EB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA9B RID: 60059
		private List<Input> method_p0;

		// Token: 0x0400EA9C RID: 60060
		private bool method_p1;
	}
}
