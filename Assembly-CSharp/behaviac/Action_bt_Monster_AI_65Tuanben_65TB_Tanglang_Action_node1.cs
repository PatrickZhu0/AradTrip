using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C8F RID: 11407
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node1 : Action
	{
		// Token: 0x06014215 RID: 82453 RVA: 0x0060BB10 File Offset: 0x00609F10
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node1()
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
			item.skillID = 20751;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014216 RID: 82454 RVA: 0x0060BBA0 File Offset: 0x00609FA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBD2 RID: 56274
		private List<Input> method_p0;

		// Token: 0x0400DBD3 RID: 56275
		private bool method_p1;
	}
}
