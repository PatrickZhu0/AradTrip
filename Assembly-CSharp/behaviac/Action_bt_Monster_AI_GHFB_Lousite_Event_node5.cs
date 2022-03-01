using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032D5 RID: 13013
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_Lousite_Event_node5 : Action
	{
		// Token: 0x06014E1B RID: 85531 RVA: 0x0064A588 File Offset: 0x00648988
		public Action_bt_Monster_AI_GHFB_Lousite_Event_node5()
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
			item.skillID = 20173;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E1C RID: 85532 RVA: 0x0064A618 File Offset: 0x00648A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6FA RID: 59130
		private List<Input> method_p0;

		// Token: 0x0400E6FB RID: 59131
		private bool method_p1;
	}
}
