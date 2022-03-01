using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002C3A RID: 11322
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node21 : Action
	{
		// Token: 0x06014172 RID: 82290 RVA: 0x006084B4 File Offset: 0x006068B4
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node21()
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
			item.skillID = 20778;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014173 RID: 82291 RVA: 0x00608544 File Offset: 0x00606944
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB32 RID: 56114
		private List<Input> method_p0;

		// Token: 0x0400DB33 RID: 56115
		private bool method_p1;
	}
}
