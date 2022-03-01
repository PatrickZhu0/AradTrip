using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C93 RID: 11411
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node8 : Action
	{
		// Token: 0x0601421D RID: 82461 RVA: 0x0060BC90 File Offset: 0x0060A090
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node8()
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
			item.skillID = 20752;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601421E RID: 82462 RVA: 0x0060BD20 File Offset: 0x0060A120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBD9 RID: 56281
		private List<Input> method_p0;

		// Token: 0x0400DBDA RID: 56282
		private bool method_p1;
	}
}
