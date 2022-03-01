using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034DD RID: 13533
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node15 : Action
	{
		// Token: 0x060151FF RID: 86527 RVA: 0x0065DA04 File Offset: 0x0065BE04
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Action_node15()
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
			item.skillID = 6256;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015200 RID: 86528 RVA: 0x0065DA94 File Offset: 0x0065BE94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB15 RID: 60181
		private List<Input> method_p0;

		// Token: 0x0400EB16 RID: 60182
		private bool method_p1;
	}
}
