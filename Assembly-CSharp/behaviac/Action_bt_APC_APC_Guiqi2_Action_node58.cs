using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D27 RID: 7463
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi2_Action_node58 : Action
	{
		// Token: 0x06012411 RID: 74769 RVA: 0x00552350 File Offset: 0x00550750
		public Action_bt_APC_APC_Guiqi2_Action_node58()
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
			item.skillID = 9733;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012412 RID: 74770 RVA: 0x005523E0 File Offset: 0x005507E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE00 RID: 48640
		private List<Input> method_p0;

		// Token: 0x0400BE01 RID: 48641
		private bool method_p1;
	}
}
