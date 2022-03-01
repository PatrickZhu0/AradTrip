using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026A7 RID: 9895
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node34 : Action
	{
		// Token: 0x06013692 RID: 79506 RVA: 0x005C74A0 File Offset: 0x005C58A0
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node34()
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
			item.skillID = 2008;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013693 RID: 79507 RVA: 0x005C7530 File Offset: 0x005C5930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0E5 RID: 53477
		private List<Input> method_p0;

		// Token: 0x0400D0E6 RID: 53478
		private bool method_p1;
	}
}
