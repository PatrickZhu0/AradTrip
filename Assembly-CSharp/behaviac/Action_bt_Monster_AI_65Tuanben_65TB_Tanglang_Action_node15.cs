using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C97 RID: 11415
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node15 : Action
	{
		// Token: 0x06014225 RID: 82469 RVA: 0x0060BE10 File Offset: 0x0060A210
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node15()
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
			item.skillID = 20753;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014226 RID: 82470 RVA: 0x0060BEA0 File Offset: 0x0060A2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBE0 RID: 56288
		private List<Input> method_p0;

		// Token: 0x0400DBE1 RID: 56289
		private bool method_p1;
	}
}
