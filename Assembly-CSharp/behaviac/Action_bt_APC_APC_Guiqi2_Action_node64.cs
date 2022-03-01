using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D23 RID: 7459
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi2_Action_node64 : Action
	{
		// Token: 0x06012409 RID: 74761 RVA: 0x0055219C File Offset: 0x0055059C
		public Action_bt_APC_APC_Guiqi2_Action_node64()
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
			item.skillID = 9734;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601240A RID: 74762 RVA: 0x0055222C File Offset: 0x0055062C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDF8 RID: 48632
		private List<Input> method_p0;

		// Token: 0x0400BDF9 RID: 48633
		private bool method_p1;
	}
}
