using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DEE RID: 7662
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node4 : Action
	{
		// Token: 0x06012592 RID: 75154 RVA: 0x0055B82C File Offset: 0x00559C2C
		public Action_bt_APC_APC_Nianqishi_Action_node4()
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
			item.skillID = 9706;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012593 RID: 75155 RVA: 0x0055B8BC File Offset: 0x00559CBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF87 RID: 49031
		private List<Input> method_p0;

		// Token: 0x0400BF88 RID: 49032
		private bool method_p1;
	}
}
