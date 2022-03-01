using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035EF RID: 13807
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node6 : Action
	{
		// Token: 0x06015405 RID: 87045 RVA: 0x00667F64 File Offset: 0x00666364
		public Action_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node6()
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
			item.skillID = 5379;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015406 RID: 87046 RVA: 0x00667FF4 File Offset: 0x006663F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDC0 RID: 60864
		private List<Input> method_p0;

		// Token: 0x0400EDC1 RID: 60865
		private bool method_p1;
	}
}
