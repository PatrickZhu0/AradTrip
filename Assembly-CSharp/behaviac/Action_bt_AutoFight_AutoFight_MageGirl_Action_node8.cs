using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002687 RID: 9863
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node8 : Action
	{
		// Token: 0x06013652 RID: 79442 RVA: 0x005C6700 File Offset: 0x005C4B00
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node8()
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
			item.skillID = 2007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013653 RID: 79443 RVA: 0x005C6790 File Offset: 0x005C4B90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0A5 RID: 53413
		private List<Input> method_p0;

		// Token: 0x0400D0A6 RID: 53414
		private bool method_p1;
	}
}
