using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002683 RID: 9859
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Action_node4 : Action
	{
		// Token: 0x0601364A RID: 79434 RVA: 0x005C654C File Offset: 0x005C494C
		public Action_bt_AutoFight_AutoFight_MageGirl_Action_node4()
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

		// Token: 0x0601364B RID: 79435 RVA: 0x005C65DC File Offset: 0x005C49DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D09D RID: 53405
		private List<Input> method_p0;

		// Token: 0x0400D09E RID: 53406
		private bool method_p1;
	}
}
