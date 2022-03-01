using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020029E1 RID: 10721
	[GeneratedTypeMetaInfo]
	internal class Action_bt_BOSS_BOSS20_4_Action_node2 : Action
	{
		// Token: 0x06013CF5 RID: 81141 RVA: 0x005EDF0C File Offset: 0x005EC30C
		public Action_bt_BOSS_BOSS20_4_Action_node2()
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
			item.skillID = 5521;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013CF6 RID: 81142 RVA: 0x005EDF9C File Offset: 0x005EC39C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D767 RID: 55143
		private List<Input> method_p0;

		// Token: 0x0400D768 RID: 55144
		private bool method_p1;
	}
}
