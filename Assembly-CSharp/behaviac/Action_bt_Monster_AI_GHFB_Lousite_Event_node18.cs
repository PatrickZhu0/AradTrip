using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032D3 RID: 13011
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_Lousite_Event_node18 : Action
	{
		// Token: 0x06014E17 RID: 85527 RVA: 0x0064A494 File Offset: 0x00648894
		public Action_bt_Monster_AI_GHFB_Lousite_Event_node18()
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
			item.skillID = 20176;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E18 RID: 85528 RVA: 0x0064A524 File Offset: 0x00648924
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6F7 RID: 59127
		private List<Input> method_p0;

		// Token: 0x0400E6F8 RID: 59128
		private bool method_p1;
	}
}
