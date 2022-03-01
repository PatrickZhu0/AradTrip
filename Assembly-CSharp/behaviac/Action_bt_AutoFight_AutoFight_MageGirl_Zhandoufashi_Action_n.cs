using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002706 RID: 9990
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node75 : Action
	{
		// Token: 0x0601374E RID: 79694 RVA: 0x005CC1C4 File Offset: 0x005CA5C4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node75()
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
			item.skillID = 2113;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601374F RID: 79695 RVA: 0x005CC254 File Offset: 0x005CA654
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1A5 RID: 53669
		private List<Input> method_p0;

		// Token: 0x0400D1A6 RID: 53670
		private bool method_p1;
	}
}
