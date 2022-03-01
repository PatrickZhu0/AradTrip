using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032D0 RID: 13008
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_Lousite_Event_node15 : Action
	{
		// Token: 0x06014E11 RID: 85521 RVA: 0x0064A334 File Offset: 0x00648734
		public Action_bt_Monster_AI_GHFB_Lousite_Event_node15()
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
			item.skillID = 20180;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E12 RID: 85522 RVA: 0x0064A3C4 File Offset: 0x006487C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F3 RID: 59123
		private List<Input> method_p0;

		// Token: 0x0400E6F4 RID: 59124
		private bool method_p1;
	}
}
