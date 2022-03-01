using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020034A2 RID: 13474
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node48 : Action
	{
		// Token: 0x0601518C RID: 86412 RVA: 0x0065B750 File Offset: 0x00659B50
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node48()
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
			item.skillID = 6205;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601518D RID: 86413 RVA: 0x0065B7E0 File Offset: 0x00659BE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA8D RID: 60045
		private List<Input> method_p0;

		// Token: 0x0400EA8E RID: 60046
		private bool method_p1;
	}
}
