using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020027BA RID: 10170
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node10 : Action
	{
		// Token: 0x060138B3 RID: 80051 RVA: 0x005D4304 File Offset: 0x005D2704
		public Action_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node10()
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
			item.skillID = 3616;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060138B4 RID: 80052 RVA: 0x005D4394 File Offset: 0x005D2794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D311 RID: 54033
		private List<Input> method_p0;

		// Token: 0x0400D312 RID: 54034
		private bool method_p1;
	}
}
