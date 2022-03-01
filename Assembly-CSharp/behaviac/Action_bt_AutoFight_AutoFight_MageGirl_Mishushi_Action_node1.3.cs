using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026ED RID: 9965
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node19 : Action
	{
		// Token: 0x0601371D RID: 79645 RVA: 0x005C9FD0 File Offset: 0x005C83D0
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node19()
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
			item.skillID = 2005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601371E RID: 79646 RVA: 0x005CA060 File Offset: 0x005C8460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D173 RID: 53619
		private List<Input> method_p0;

		// Token: 0x0400D174 RID: 53620
		private bool method_p1;
	}
}
