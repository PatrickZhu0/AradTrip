using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029D8 RID: 10712
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node135 : Action
	{
		// Token: 0x06013CE4 RID: 81124 RVA: 0x005EBEE8 File Offset: 0x005EA2E8
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node135()
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
			item.skillID = 1819;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CE5 RID: 81125 RVA: 0x005EBF78 File Offset: 0x005EA378
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D755 RID: 55125
		private List<Input> method_p0;

		// Token: 0x0400D756 RID: 55126
		private bool method_p1;
	}
}
