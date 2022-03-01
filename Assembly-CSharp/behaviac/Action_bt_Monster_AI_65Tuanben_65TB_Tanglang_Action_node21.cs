using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C9F RID: 11423
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node21 : Action
	{
		// Token: 0x06014235 RID: 82485 RVA: 0x0060C110 File Offset: 0x0060A510
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node21()
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
			item.skillID = 20755;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014236 RID: 82486 RVA: 0x0060C1A0 File Offset: 0x0060A5A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBEE RID: 56302
		private List<Input> method_p0;

		// Token: 0x0400DBEF RID: 56303
		private bool method_p1;
	}
}
