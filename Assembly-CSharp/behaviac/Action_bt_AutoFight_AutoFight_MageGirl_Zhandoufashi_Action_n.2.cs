using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200270C RID: 9996
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node81 : Action
	{
		// Token: 0x0601375A RID: 79706 RVA: 0x005CC438 File Offset: 0x005CA838
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node81()
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
			item.skillID = 2327;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601375B RID: 79707 RVA: 0x005CC4C8 File Offset: 0x005CA8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1B3 RID: 53683
		private List<Input> method_p0;

		// Token: 0x0400D1B4 RID: 53684
		private bool method_p1;
	}
}
