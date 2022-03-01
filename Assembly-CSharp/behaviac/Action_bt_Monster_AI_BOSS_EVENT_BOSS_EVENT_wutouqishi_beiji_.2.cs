using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020030C8 RID: 12488
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node6 : Action
	{
		// Token: 0x06014A4B RID: 84555 RVA: 0x006374D4 File Offset: 0x006358D4
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node6()
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
			item.skillID = 5636;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014A4C RID: 84556 RVA: 0x00637564 File Offset: 0x00635964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B4 RID: 58292
		private List<Input> method_p0;

		// Token: 0x0400E3B5 RID: 58293
		private bool method_p1;
	}
}
