using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E08 RID: 15880
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node21 : Action
	{
		// Token: 0x06016399 RID: 91033 RVA: 0x006B8154 File Offset: 0x006B6554
		public Action_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node21()
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
			item.skillID = 5198;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601639A RID: 91034 RVA: 0x006B81E4 File Offset: 0x006B65E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBFF RID: 64511
		private List<Input> method_p0;

		// Token: 0x0400FC00 RID: 64512
		private bool method_p1;
	}
}
