using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020030EA RID: 12522
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4 : Action
	{
		// Token: 0x06014A87 RID: 84615 RVA: 0x00638704 File Offset: 0x00636B04
		public Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node4()
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
			item.skillID = 20705;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014A88 RID: 84616 RVA: 0x00638794 File Offset: 0x00636B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3F6 RID: 58358
		private List<Input> method_p0;

		// Token: 0x0400E3F7 RID: 58359
		private bool method_p1;
	}
}
