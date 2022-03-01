using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002723 RID: 10019
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node51 : Action
	{
		// Token: 0x06013788 RID: 79752 RVA: 0x005CCE10 File Offset: 0x005CB210
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node51()
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
			item.skillID = 2311;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013789 RID: 79753 RVA: 0x005CCEA0 File Offset: 0x005CB2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E1 RID: 53729
		private List<Input> method_p0;

		// Token: 0x0400D1E2 RID: 53730
		private bool method_p1;
	}
}
