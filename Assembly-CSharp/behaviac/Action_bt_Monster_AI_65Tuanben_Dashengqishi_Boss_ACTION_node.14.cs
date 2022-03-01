using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002DB1 RID: 11697
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node21 : Action
	{
		// Token: 0x06014443 RID: 83011 RVA: 0x00616500 File Offset: 0x00614900
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node21()
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
			item.skillID = 21647;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014444 RID: 83012 RVA: 0x00616590 File Offset: 0x00614990
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE0A RID: 56842
		private List<Input> method_p0;

		// Token: 0x0400DE0B RID: 56843
		private bool method_p1;
	}
}
