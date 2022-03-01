using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020031ED RID: 12781
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node7 : Action
	{
		// Token: 0x06014C66 RID: 85094 RVA: 0x006422A8 File Offset: 0x006406A8
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node7()
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
			item.skillID = 21564;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06014C67 RID: 85095 RVA: 0x00642338 File Offset: 0x00640738
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5C0 RID: 58816
		private List<Input> method_p0;

		// Token: 0x0400E5C1 RID: 58817
		private bool method_p1;
	}
}
