using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020032CD RID: 13005
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GHFB_Lousite_Event_node11 : Action
	{
		// Token: 0x06014E0B RID: 85515 RVA: 0x0064A1D4 File Offset: 0x006485D4
		public Action_bt_Monster_AI_GHFB_Lousite_Event_node11()
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
			item.skillID = 20181;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014E0C RID: 85516 RVA: 0x0064A264 File Offset: 0x00648664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6EF RID: 59119
		private List<Input> method_p0;

		// Token: 0x0400E6F0 RID: 59120
		private bool method_p1;
	}
}
