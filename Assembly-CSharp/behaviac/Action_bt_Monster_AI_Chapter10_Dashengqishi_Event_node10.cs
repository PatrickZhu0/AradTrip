using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020030E6 RID: 12518
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node10 : Action
	{
		// Token: 0x06014A7F RID: 84607 RVA: 0x00638574 File Offset: 0x00636974
		public Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node10()
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
			item.skillID = 20707;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014A80 RID: 84608 RVA: 0x00638604 File Offset: 0x00636A04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3EE RID: 58350
		private List<Input> method_p0;

		// Token: 0x0400E3EF RID: 58351
		private bool method_p1;
	}
}
