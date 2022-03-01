using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002D9E RID: 11678
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node37 : Action
	{
		// Token: 0x0601441D RID: 82973 RVA: 0x00615D28 File Offset: 0x00614128
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node37()
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
			item.skillID = 21645;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601441E RID: 82974 RVA: 0x00615DB8 File Offset: 0x006141B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE4 RID: 56804
		private List<Input> method_p0;

		// Token: 0x0400DDE5 RID: 56805
		private bool method_p1;
	}
}
