using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200310C RID: 12556
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2 : Action
	{
		// Token: 0x06014AC3 RID: 84675 RVA: 0x00639A4C File Offset: 0x00637E4C
		public Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2()
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
			item.skillID = 20721;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014AC4 RID: 84676 RVA: 0x00639ADC File Offset: 0x00637EDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E433 RID: 58419
		private List<Input> method_p0;

		// Token: 0x0400E434 RID: 58420
		private bool method_p1;
	}
}
