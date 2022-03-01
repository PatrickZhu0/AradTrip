using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029A6 RID: 10662
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node39 : Action
	{
		// Token: 0x06013C80 RID: 81024 RVA: 0x005EA934 File Offset: 0x005E8D34
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node39()
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
			item.skillID = 1521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C81 RID: 81025 RVA: 0x005EA9C4 File Offset: 0x005E8DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6EB RID: 55019
		private List<Input> method_p0;

		// Token: 0x0400D6EC RID: 55020
		private bool method_p1;
	}
}
