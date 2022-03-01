using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002713 RID: 10003
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node15 : Action
	{
		// Token: 0x06013768 RID: 79720 RVA: 0x005CC740 File Offset: 0x005CAB40
		public Action_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node15()
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
			item.skillID = 2111;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013769 RID: 79721 RVA: 0x005CC7D0 File Offset: 0x005CABD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C1 RID: 53697
		private List<Input> method_p0;

		// Token: 0x0400D1C2 RID: 53698
		private bool method_p1;
	}
}
