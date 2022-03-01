using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002697 RID: 9879
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node58 : Action
	{
		// Token: 0x06013672 RID: 79474 RVA: 0x005C6DD0 File Offset: 0x005C51D0
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node58()
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
			item.skillID = 2003;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013673 RID: 79475 RVA: 0x005C6E60 File Offset: 0x005C5260
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0C5 RID: 53445
		private List<Input> method_p0;

		// Token: 0x0400D0C6 RID: 53446
		private bool method_p1;
	}
}
