using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D1F RID: 7455
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi2_Action_node100 : Action
	{
		// Token: 0x06012401 RID: 74753 RVA: 0x00551FE8 File Offset: 0x005503E8
		public Action_bt_APC_APC_Guiqi2_Action_node100()
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
			item.skillID = 9726;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012402 RID: 74754 RVA: 0x00552078 File Offset: 0x00550478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDF0 RID: 48624
		private List<Input> method_p0;

		// Token: 0x0400BDF1 RID: 48625
		private bool method_p1;
	}
}
