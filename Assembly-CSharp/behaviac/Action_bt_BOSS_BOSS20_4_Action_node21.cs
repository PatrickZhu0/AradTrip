using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029F2 RID: 10738
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node21 : Action
	{
		// Token: 0x06013D17 RID: 81175 RVA: 0x005EE640 File Offset: 0x005ECA40
		public Action_bt_BOSS_BOSS20_4_Action_node21()
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
			item.skillID = 5051;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013D18 RID: 81176 RVA: 0x005EE6D0 File Offset: 0x005ECAD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D78A RID: 55178
		private List<Input> method_p0;

		// Token: 0x0400D78B RID: 55179
		private bool method_p1;
	}
}
