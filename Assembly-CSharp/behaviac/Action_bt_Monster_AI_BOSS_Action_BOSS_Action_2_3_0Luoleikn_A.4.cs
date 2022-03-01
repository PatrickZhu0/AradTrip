using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F61 RID: 12129
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node22 : Action
	{
		// Token: 0x06014791 RID: 83857 RVA: 0x00628F40 File Offset: 0x00627340
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node22()
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
			item.skillID = 5051;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014792 RID: 83858 RVA: 0x00628FD0 File Offset: 0x006273D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0FF RID: 57599
		private List<Input> method_p0;

		// Token: 0x0400E100 RID: 57600
		private bool method_p1;
	}
}
