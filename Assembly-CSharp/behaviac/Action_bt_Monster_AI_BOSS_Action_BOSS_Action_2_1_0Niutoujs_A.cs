using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002F44 RID: 12100
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node7 : Action
	{
		// Token: 0x06014758 RID: 83800 RVA: 0x00627E08 File Offset: 0x00626208
		public Action_bt_Monster_AI_BOSS_Action_BOSS_Action_2_1_0Niutoujs_Action_node7()
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
			item.skillID = 5004;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014759 RID: 83801 RVA: 0x00627E98 File Offset: 0x00626298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0C7 RID: 57543
		private List<Input> method_p0;

		// Token: 0x0400E0C8 RID: 57544
		private bool method_p1;
	}
}
