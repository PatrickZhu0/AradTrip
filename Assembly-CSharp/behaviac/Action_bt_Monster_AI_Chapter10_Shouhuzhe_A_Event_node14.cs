using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200312D RID: 12589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node14 : Action
	{
		// Token: 0x06014AFF RID: 84735 RVA: 0x0063AA78 File Offset: 0x00638E78
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node14()
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
			item.skillID = 20618;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B00 RID: 84736 RVA: 0x0063AB08 File Offset: 0x00638F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E472 RID: 58482
		private List<Input> method_p0;

		// Token: 0x0400E473 RID: 58483
		private bool method_p1;
	}
}
