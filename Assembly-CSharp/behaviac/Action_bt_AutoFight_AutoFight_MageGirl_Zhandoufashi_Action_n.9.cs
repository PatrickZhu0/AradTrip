using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002727 RID: 10023
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node56 : Action
	{
		// Token: 0x06013790 RID: 79760 RVA: 0x005CCFC4 File Offset: 0x005CB3C4
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node56()
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
			item.skillID = 2313;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013791 RID: 79761 RVA: 0x005CD054 File Offset: 0x005CB454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1E9 RID: 53737
		private List<Input> method_p0;

		// Token: 0x0400D1EA RID: 53738
		private bool method_p1;
	}
}
