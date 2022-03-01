using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003147 RID: 12615
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node19 : Action
	{
		// Token: 0x06014B31 RID: 84785 RVA: 0x0063B94C File Offset: 0x00639D4C
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node19()
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
			item.skillID = 20620;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014B32 RID: 84786 RVA: 0x0063B9DC File Offset: 0x00639DDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A9 RID: 58537
		private List<Input> method_p0;

		// Token: 0x0400E4AA RID: 58538
		private bool method_p1;
	}
}
