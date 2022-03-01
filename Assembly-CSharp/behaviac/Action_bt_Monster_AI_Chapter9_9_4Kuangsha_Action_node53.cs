using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003180 RID: 12672
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node53 : Action
	{
		// Token: 0x06014B97 RID: 84887 RVA: 0x0063D724 File Offset: 0x0063BB24
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node53()
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
			item.skillID = 21541;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B98 RID: 84888 RVA: 0x0063D7B4 File Offset: 0x0063BBB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E502 RID: 58626
		private List<Input> method_p0;

		// Token: 0x0400E503 RID: 58627
		private bool method_p1;
	}
}
