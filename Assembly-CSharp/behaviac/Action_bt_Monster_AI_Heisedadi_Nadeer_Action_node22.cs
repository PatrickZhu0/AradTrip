using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034E1 RID: 13537
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node22 : Action
	{
		// Token: 0x06015207 RID: 86535 RVA: 0x0065DBD0 File Offset: 0x0065BFD0
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node22()
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
			item.skillID = 6257;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015208 RID: 86536 RVA: 0x0065DC60 File Offset: 0x0065C060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB1F RID: 60191
		private List<Input> method_p0;

		// Token: 0x0400EB20 RID: 60192
		private bool method_p1;
	}
}
