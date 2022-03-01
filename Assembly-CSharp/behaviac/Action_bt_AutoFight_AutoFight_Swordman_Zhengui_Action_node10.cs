using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029B4 RID: 10676
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node106 : Action
	{
		// Token: 0x06013C9C RID: 81052 RVA: 0x005EAF10 File Offset: 0x005E9310
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node106()
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
			item.skillID = 1805;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C9D RID: 81053 RVA: 0x005EAFA0 File Offset: 0x005E93A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D709 RID: 55049
		private List<Input> method_p0;

		// Token: 0x0400D70A RID: 55050
		private bool method_p1;
	}
}
