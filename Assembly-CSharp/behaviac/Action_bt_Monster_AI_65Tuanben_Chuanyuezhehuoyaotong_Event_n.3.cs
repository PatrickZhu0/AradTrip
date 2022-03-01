using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D5C RID: 11612
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node13 : Action
	{
		// Token: 0x0601439B RID: 82843 RVA: 0x00613560 File Offset: 0x00611960
		public Action_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node13()
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
			item.skillID = 21856;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601439C RID: 82844 RVA: 0x006135F0 File Offset: 0x006119F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD66 RID: 56678
		private List<Input> method_p0;

		// Token: 0x0400DD67 RID: 56679
		private bool method_p1;
	}
}
