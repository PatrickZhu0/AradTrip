using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B0F RID: 15119
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node10 : Action
	{
		// Token: 0x06015DD8 RID: 89560 RVA: 0x0069B4D8 File Offset: 0x006998D8
		public Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node10()
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
			item.skillID = 21021;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015DD9 RID: 89561 RVA: 0x0069B568 File Offset: 0x00699968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6C6 RID: 63174
		private List<Input> method_p0;

		// Token: 0x0400F6C7 RID: 63175
		private bool method_p1;
	}
}
