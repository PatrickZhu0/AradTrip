using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200272B RID: 10027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node61 : Action
	{
		// Token: 0x06013798 RID: 79768 RVA: 0x005CD178 File Offset: 0x005CB578
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node61()
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
			item.skillID = 2310;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013799 RID: 79769 RVA: 0x005CD208 File Offset: 0x005CB608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1F1 RID: 53745
		private List<Input> method_p0;

		// Token: 0x0400D1F2 RID: 53746
		private bool method_p1;
	}
}
