using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001D18 RID: 7448
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Guiqi2_Action_node75 : Action
	{
		// Token: 0x060123F3 RID: 74739 RVA: 0x00551CF8 File Offset: 0x005500F8
		public Action_bt_APC_APC_Guiqi2_Action_node75()
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
			item.skillID = 9725;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060123F4 RID: 74740 RVA: 0x00551D88 File Offset: 0x00550188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE4 RID: 48612
		private List<Input> method_p0;

		// Token: 0x0400BDE5 RID: 48613
		private bool method_p1;
	}
}
