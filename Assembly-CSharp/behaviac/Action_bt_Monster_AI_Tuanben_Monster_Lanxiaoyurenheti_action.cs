using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B0C RID: 15116
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node9 : Action
	{
		// Token: 0x06015DD2 RID: 89554 RVA: 0x0069B368 File Offset: 0x00699768
		public Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node9()
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
			item.skillID = 21300;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015DD3 RID: 89555 RVA: 0x0069B3F8 File Offset: 0x006997F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6BF RID: 63167
		private List<Input> method_p0;

		// Token: 0x0400F6C0 RID: 63168
		private bool method_p1;
	}
}
